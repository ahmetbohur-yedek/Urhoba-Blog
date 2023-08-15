#include "urhoba.h"

UrhobaServer::UrhobaServer(String server_name, IPAddress ip_address, int port) {
  serverName = server_name;
  targetIP = ip_address;
  targetPort = port;
}

IPAddress UrhobaServer::getTargetIP() const {
  return targetIP;
}

int UrhobaServer::getTargetPort() const {
  return targetPort;
}

String UrhobaServer::getServerName() const {
  return serverName;
}

bool UrhobaServer::getServerStatus() const {
  WiFiClient client;

  IPAddress serverIP = targetIP;
  int serverPort = targetPort;

  int maxAttempts = 3;
  unsigned long startTime = millis();
  for (int i = 0; i < maxAttempts; i++) {
    if (client.connect(serverIP, serverPort)) {
      client.stop();
      return true;
    }
    unsigned long currentTime = millis();
    if (currentTime - startTime >= 100) {
      startTime = currentTime;
    }
  }
  return false;
}

void UrhobaServer::setServerName(String server_name) {
  serverName = server_name;
}

void UrhobaServer::setServerPort(int port) {
  targetPort = port;
}

void UrhobaServer::setServerIp(IPAddress ip_address) {
  targetIP = ip_address;
}

Account::Account(String chat_id) {
  chatId = chat_id;
}

String Account::getChatId() {
  return chatId;
}

bool Account::addServer(String server_name, IPAddress ip_address, int port) {
  for (const UrhobaServer& server : servers) {
    if (server.getTargetIP() == ip_address && server.getTargetPort() == port) {
      return false;
    }
  }
  UrhobaServer addedServer(server_name, ip_address, port);
  servers.push_back(addedServer);
  return true;
}

bool Account::removeServer(int server_index) {
  if (server_index >= 0 && server_index < servers.size()) {
    servers.erase(servers.begin() + server_index);
    return true;
  }
  return false;
}

UrhobaServer Account::getServer(int server_index) {
  if (server_index >= 0 && server_index < servers.size()) {
    return servers[server_index];
  }
  return UrhobaServer("", IPAddress(0, 0, 0, 0), 0);
}

UrhobaServer& Account::getServerRef(int server_index) {
  if (server_index >= 0 && server_index < servers.size()) {
    return servers[server_index];
  }
  static UrhobaServer dummyServer("", IPAddress(0, 0, 0, 0), 0);
  return dummyServer;
}

std::vector<UrhobaServer> Account::getAllServers() {
  return servers;
}

std::vector<UrhobaServer> Account::getAllServersConst() const {
  return servers;
}


bool AccountManager::addAccount(String chat_id) {
  bool accountExists = false;
  for (int i = 0; i < accounts.size(); i++) {
    if (accounts[i].getChatId() == chat_id) {
      accountExists = true;
      break;
    }
  }

  if (!accountExists) {
    accounts.push_back(Account(chat_id));
    return true;
  } else {
    return false;
  }
}

bool AccountManager::removeAccount(String chat_id) {
  for (int i = 0; i < accounts.size(); i++) {
    if (accounts[i].getChatId() == chat_id) {
      accounts.erase(accounts.begin() + i);
      return true;
    }
  }

  return false;
}

Account* AccountManager::findAccount(String chat_id) {
  for (int i = 0; i < accounts.size(); i++) {
    if (accounts[i].getChatId() == chat_id) {
      return &accounts[i];
    }
  }
  return nullptr;
}

std::vector<Account> AccountManager::getAccounts() {
  return accounts;
}