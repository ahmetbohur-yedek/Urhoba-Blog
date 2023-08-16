// www.urhoba.net
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <WiFiClientSecure.h>
#include <UniversalTelegramBot.h>
#include <LittleFS.h>
#include <ArduinoJson.h>
#include "urhoba.h"

#define WIFI_SSID ""
#define WIFI_PASSWORD ""
#define BOT_TOKEN ":"

AccountManager accountManager;

const unsigned long BOT_MTBS = 1000;

X509List cert(TELEGRAM_CERTIFICATE_ROOT);
WiFiClientSecure secured_client;
UniversalTelegramBot bot(BOT_TOKEN, secured_client);
unsigned long bot_lasttime;

const unsigned long SERVER_CHECK_INTERVAL = 1800000;
unsigned long lastServerCheckTime = 0;

// Start messages
void startMessage(String chat_id, String text, String from_name) {
  if (text == "/start") {
    String msg = "Welcome to UrhobA Server Checker System, " + from_name + ".\n\n";
    msg += "This system is designed to help you monitor the status of your server's ports. If any port crashes, you'll receive a notification message to keep you informed.\n";
    msg += "To get started, use the /commands command to see a list of available commands.\n";
    msg += "Feel free to explore the system and manage your server effortlessly!";
    bot.sendMessage(chat_id, msg, "");
  }
}

// Command messages
void commandsMessage(String chat_id, String text, String from_name) {
  if (text == "/commands") {
    String msg = "Hello " + from_name + "!\n\n";
    msg += "Available commands:\n\n";
    msg += "Account:\n";
    msg += "/register: Create a new account.\n";
    msg += "/remove: Remove your account.\n\n";
    msg += "Server:\n";
    msg += "/add_server [ip] [port] [name]: Add a new server.\n";
    msg += "/remove_server [index]: Remove a server.\n";
    msg += "/get_server [index]: Get server details.\n";
    msg += "/set_server_name [index] [name]: Set server name.\n";
    msg += "/set_server_port [index] [port]: Set server port.\n";
    msg += "/set_server_ip [index] [ip]: Set server ip.\n";
    msg += "/get_servers: List all your servers.\n";
    msg += "/stats: Show bot stats.\n\n";
    msg += "For more info or help, feel free to ask. Enjoy using our system!";
    bot.sendMessage(chat_id, msg, "");
  }
}

// Create account
void registerCommand(String chat_id, String text, String from_name) {
  if (text == "/register") {
    String msg = "Your registration request has been received.";

    bot.sendMessage(chat_id, msg, "");

    bool accountAdded = accountManager.addAccount(chat_id);

    if (accountAdded) {
      msg = "You have successfully registered!";
      saveAccountsToFile();
    } else {
      msg = "Your account already exists!";
    }

    bot.sendMessage(chat_id, msg, "");
  }
}

// Remove account
void removeCommand(String chat_id, String text, String from_name) {
  if (text == "/remove") {
    String msg = "Removing your account.";

    bot.sendMessage(chat_id, msg, "");

    bool found = accountManager.removeAccount(chat_id);

    if (found) {
      msg = "Your account has been removed.";
      saveAccountsToFile();
    } else {
      msg = "Your account does not exist.";
    }

    bot.sendMessage(chat_id, msg, "");
  }
}

// Add server to account
void addServerCommand(String chat_id, String text, String from_name) {
  if (text.startsWith("/add_server")) {
    String msg;

    // Extracting server address, port, and server name from text
    int ip_start = text.indexOf("[") + 1;
    int ip_end = text.indexOf("]");
    int port_start = text.indexOf("[", ip_end) + 1;
    int port_end = text.indexOf("]", port_start);
    int name_start = text.indexOf("[", port_end) + 1;
    int name_end = text.indexOf("]", name_start);

    if (ip_start != -1 && ip_end != -1 && port_start != -1 && port_end != -1 && name_start != -1 && name_end != -1) {
      String server_address = text.substring(ip_start, ip_end);
      String port_str = text.substring(port_start, port_end);
      String server_name = text.substring(name_start, name_end);

      IPAddress ip_address;
      if (WiFi.hostByName(server_address.c_str(), ip_address)) {
        int port = port_str.toInt();

        Account* account = accountManager.findAccount(chat_id);
        if (account) {
          bool serverAdded = account->addServer(server_name, ip_address, port);
          if (serverAdded) {
            msg = "Server added successfully!";
            saveAccountsToFile();
          } else {
            msg = "Server with the same IP address and port already exists.";
          }
        } else {
          msg = "Account not found. Please register first.";
        }
      } else {
        msg = "Invalid server address.";
      }
    } else {
      msg = "Invalid format. Please use /add_server [server_address] [port] [server_name].";
    }

    bot.sendMessage(chat_id, msg, "");
  }
}

// Remove server to account
void removeServerCommand(String chat_id, String text, String from_name) {
  if (text.startsWith("/remove_server")) {
    String msg;

    int index_start = text.indexOf("[") + 1;
    int index_end = text.indexOf("]");

    if (index_start != -1 && index_end != -1) {
      String index_str = text.substring(index_start, index_end);

      int server_index = index_str.toInt();

      Account* account = accountManager.findAccount(chat_id);

      if (account) {
        bool serverRemoved = account->removeServer(server_index);

        if (serverRemoved) {
          msg = "Server removed successfully!";
          saveAccountsToFile();
        } else {
          msg = "Invalid server index.";
        }
      } else {
        msg = "Account not found. Please register first.";
      }
    } else {
      msg = "Invalid format. Please use /remove_server [server_index].";
    }

    bot.sendMessage(chat_id, msg, "");
  }
}

// Get server
void getServerCommand(String chat_id, String text, String from_name) {
  if (text.startsWith("/get_server")) {
    int server_index = -1;
    int index_start = text.indexOf("[") + 1;
    int index_end = text.indexOf("]");

    if (index_start != -1 && index_end != -1) {
      String index_str = text.substring(index_start, index_end);
      server_index = index_str.toInt();
    }

    if (server_index >= 0) {
      Account* account = accountManager.findAccount(chat_id);

      if (account) {
        UrhobaServer server = account->getServer(server_index);

        if (server.getTargetPort() != -1) {
          String msg = "Here is server number " + String(server_index) + ":\n";
          msg += "Name: " + server.getServerName() + "\n";
          msg += "IP: " + server.getTargetIP().toString() + "\n";
          msg += "Port: " + String(server.getTargetPort()) + "\n";
          msg += "Status: " + String(server.getServerStatus()) + "\n";

          bot.sendMessage(chat_id, msg, "");
        } else {
          bot.sendMessage(chat_id, "Invalid server index.", "");
        }
      } else {
        bot.sendMessage(chat_id, "Account not found. Please register first.", "");
      }
    } else {
      bot.sendMessage(chat_id, "Invalid server index format. Please use /get_server [server_index].", "");
    }
  }
}

// Get all servers
void getServersCommand(String chat_id, String text, String from_name) {
  if (text == "/get_servers") {
    Account* account = accountManager.findAccount(chat_id);

    if (account) {
      std::vector<UrhobaServer> servers = account->getAllServers();

      if (!servers.empty()) {
        String msg = "Here are your added servers:\n\n";

        for (int i = 0; i < servers.size(); i++) {
          UrhobaServer server = servers[i];
          msg += "[" + String(i) + "] Name: " + server.getServerName() + ", Status: " + String(server.getServerStatus()) + "\n";
        }

        msg += "\nTo view details of a specific server, use /get_server [server_index].";
        bot.sendMessage(chat_id, msg, "");
      } else {
        bot.sendMessage(chat_id, "You haven't added any servers yet.", "");
      }
    } else {
      bot.sendMessage(chat_id, "Account not found. Please register first.", "");
    }
  }
}

// Bot stats
void statsCommand(String chat_id, String text) {
  if (text == "/stats") {
    int numAccounts = accountManager.getAccounts().size();
    int totalServers = 0;

    for (const Account& account : accountManager.getAccounts()) {
      totalServers += account.getAllServersConst().size();
    }

    String msg = "Total accounts: " + String(numAccounts) + "\n";
    msg += "Total servers: " + String(totalServers);

    bot.sendMessage(chat_id, msg, "");
  }
}

// Set server name
void setServerNameCommand(String chat_id, String text) {
  if (text.startsWith("/set_server_name")) {
    int index_start = text.indexOf("[") + 1;
    int index_end = text.indexOf("]");
    int name_start = text.indexOf("[", index_end) + 1;
    int name_end = text.indexOf("]", name_start);

    if (index_start != -1 && index_end != -1 && name_start != -1 && name_end != -1) {
      String index_str = text.substring(index_start, index_end);
      String server_name = text.substring(name_start, name_end);

      int server_index = index_str.toInt();

      Account* account = accountManager.findAccount(chat_id);

      if (account) {
        UrhobaServer& server = account->getServerRef(server_index);
        server.setServerName(server_name);
        bot.sendMessage(chat_id, "Server name updated successfully!", "");
        saveAccountsToFile();
      } else {
        bot.sendMessage(chat_id, "Account not found. Please register first.", "");
      }
    } else {
      bot.sendMessage(chat_id, "Invalid format. Please use /set_server_name [server_index] [server_name].", "");
    }
  }
}

// Set server port
void setServerPortCommand(String chat_id, String text) {
  if (text.startsWith("/set_server_port")) {
    int index_start = text.indexOf("[") + 1;
    int index_end = text.indexOf("]");
    int port_start = text.indexOf("[", index_end) + 1;
    int port_end = text.indexOf("]", port_start);

    if (index_start != -1 && index_end != -1 && port_start != -1 && port_end != -1) {
      String index_str = text.substring(index_start, index_end);
      String port_str = text.substring(port_start, port_end);

      int server_index = index_str.toInt();
      int new_port = port_str.toInt();

      Account* account = accountManager.findAccount(chat_id);

      if (account) {
        UrhobaServer& server = account->getServerRef(server_index);
        server.setServerPort(new_port);
        bot.sendMessage(chat_id, "Server port updated successfully!", "");
        saveAccountsToFile();
      } else {
        bot.sendMessage(chat_id, "Account not found. Please register first.", "");
      }
    } else {
      bot.sendMessage(chat_id, "Invalid format. Please use /set_server_port [server_index] [new_port].", "");
    }
  } 
}

// Set server ip
void setServerIpCommand(String chat_id, String text) {
  if (text.startsWith("/set_server_ip")) {
    int index_start = text.indexOf("[") + 1;
    int index_end = text.indexOf("]");
    int ip_start = text.indexOf("[", index_end) + 1;
    int ip_end = text.indexOf("]", ip_start);

    if (index_start != -1 && index_end != -1 && ip_start != -1 && ip_end != -1) {
      String index_str = text.substring(index_start, index_end);
      String ip_str = text.substring(ip_start, ip_end);

      int server_index = index_str.toInt();
      IPAddress new_ip;

      if (WiFi.hostByName(ip_str.c_str(), new_ip)) {
        Account* account = accountManager.findAccount(chat_id);

        if (account) {
          UrhobaServer& server = account->getServerRef(server_index);
          server.setServerIp(new_ip);
          bot.sendMessage(chat_id, "Server IP updated successfully!", "");
          saveAccountsToFile();
        } else {
          bot.sendMessage(chat_id, "Account not found. Please register first.", "");
        }
      } else {
        bot.sendMessage(chat_id, "Invalid IP address.", "");
      }
    } else {
      bot.sendMessage(chat_id, "Invalid format. Please use /set_server_ip [server_index] [new_ip].", "");
    }
  }
}

// Handle to telegram messages
void handleNewMessages(int numNewMessages) {
  for (int i = 0; i < numNewMessages; i++) {
    String chat_id = bot.messages[i].chat_id;
    String text = bot.messages[i].text;
    String from_name = bot.messages[i].from_name;
    if (from_name == "")
      from_name = "Guest";

    startMessage(chat_id, text, from_name);
    commandsMessage(chat_id, text, from_name);
    registerCommand(chat_id, text, from_name);
    removeCommand(chat_id, text, from_name);
    addServerCommand(chat_id, text, from_name);
    statsCommand(chat_id, text);
    removeServerCommand(chat_id, text, from_name);
    setServerNameCommand(chat_id, text);
    setServerPortCommand(chat_id, text);
    setServerIpCommand(chat_id, text);
    if (text == "/get_servers")
      getServersCommand(chat_id, text, from_name);
    else
      getServerCommand(chat_id, text, from_name);
  }
}

// Check servers
void checkServers() {
  unsigned long currentTime = millis();

  if (currentTime - lastServerCheckTime >= SERVER_CHECK_INTERVAL) {
    lastServerCheckTime = currentTime;

    for (Account& account : accountManager.getAccounts()) {
      String chatId = account.getChatId();
      String msg = "Your servers:\n";

      for (int i = 0; i < account.getAllServers().size(); i++) {
        UrhobaServer& server = account.getServerRef(i);
        bool serverStatus = server.getServerStatus();

        if (!serverStatus) {
          msg += "Server Name: " + server.getServerName() + ", IP: " + server.getTargetIP().toString() + ", Port: " + String(server.getTargetPort()) + " is down.\n";
        }
      }

      if (msg != "Your servers:\n") {
        bot.sendMessage(chatId, msg, "");
      }
    }
  }
}

// Save all accounts
void saveAccountsToFile() {
  File file = LittleFS.open("/accounts.json", "w");
  if (!file) {
    Serial.println("Error opening file for writing");
    return;
  }

  DynamicJsonDocument doc(1024);
  JsonArray accountsArray = doc.createNestedArray("accounts");

  for (Account& account : accountManager.getAccounts()) {
    JsonObject accountObject = accountsArray.createNestedObject();
    accountObject["chatId"] = account.getChatId();

    JsonArray serversArray = accountObject.createNestedArray("servers");
    std::vector<UrhobaServer> servers = account.getAllServers();
    for (const UrhobaServer& server : servers) {
      JsonObject serverObject = serversArray.createNestedObject();
      serverObject["name"] = server.getServerName();
      serverObject["ip"] = server.getTargetIP().toString();
      serverObject["port"] = server.getTargetPort();
    }
  }

  serializeJson(doc, file);

  file.close();
}

// Get all accounts
void loadAccountsFromFile() {
  File file = LittleFS.open("/accounts.json", "r");
  if (!file) {
    Serial.println("Error opening file for reading");
    return;
  }

  DynamicJsonDocument doc(1024);
  DeserializationError error = deserializeJson(doc, file);

  if (error) {
    Serial.println("Error parsing JSON");
    return;
  }

  JsonArray accountsArray = doc["accounts"];

  for (const JsonVariant& accountVariant : accountsArray) {
    JsonObject accountObject = accountVariant.as<JsonObject>();
    String chatId = accountObject["chatId"].as<String>();
    accountManager.addAccount(chatId);

    JsonArray serversArray = accountObject["servers"];

    for (const JsonVariant& serverVariant : serversArray) {
      JsonObject serverObject = serverVariant.as<JsonObject>();
      String ipStr = serverObject["ip"].as<String>();
      String nameStr = serverObject["name"].as<String>();
      IPAddress ip;
      if (ip.fromString(ipStr)) {
        int port = serverObject["port"].as<int>();
        accountManager.findAccount(chatId)->addServer(nameStr, ip, port);
      }
    }
  }

  file.close();
}

void setup() {

  // WIFI & Telegram Begin

  Serial.begin(115200);
  Serial.println();

  Serial.print("Connecting to Wifi SSID ");
  Serial.print(WIFI_SSID);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  secured_client.setTrustAnchors(&cert);

  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.print("\nWiFi connected. IP address: ");
  Serial.println(WiFi.localIP());

  Serial.print("Retrieving time: ");
  configTime(0, 0, "pool.ntp.org");
  time_t now = time(nullptr);
  while (now < 24 * 3600) {
    Serial.print(".");
    delay(100);
    now = time(nullptr);
  }
  Serial.println(now);

  // Save System Begin

  LittleFS.begin();

  loadAccountsFromFile();

  // OTA Begin
  //ArduinoOTA.begin();
}

void loop() {

  // Telegram Loop

  if (millis() - bot_lasttime > BOT_MTBS) {
    int numNewMessages = bot.getUpdates(bot.last_message_received + 1);

    while (numNewMessages) {
      Serial.println("Message sending");
      handleNewMessages(numNewMessages);
      numNewMessages = bot.getUpdates(bot.last_message_received + 1);
    }

    bot_lasttime = millis();
  }

  // Server Check Loop

  checkServers();

  // OTA Loop
  //ArduinoOTA.handle();
}
