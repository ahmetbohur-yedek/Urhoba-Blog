// www.urhoba.net
#ifndef URHOBA_H
#define URHOBA_H

#include <Arduino.h>
#include <vector>
#include <IPAddress.h>

public class UrhobaServer {
private:
  IPAddress targetIP;
  int targetPort;

public:
  UrhobaServer(IPAddress ipAddress, int port) {
    targetIP = ipAddress;
    targetPort = port;
  }
};

class Account {
private:
  String chat_id;
  std::vector<UrhobaServer> servers;

public:
  Account(String chatId) {
    chat_id = chatId;
  }

  String GetChatId() {
    return chat_id;
  }

  void AddServer(IPAddress ipAddress, int port) {
    servers.push_back(UrhobaServer(ipAddress, port));
  }

  void RemoveServer(IPAddress ipAddress, int port) {
    // Burada sunucu kaldırma işlevselliğini ekleyebilirsiniz.
  }
};

class AccountsManager {
private:
  std::vector<Account> accounts;

public:
  bool AddAccount(String chat_id) {
    bool accountExists = false;
    for (int i = 0; i < accounts.size(); i++) {
      if (accounts[i].GetChatId() == chat_id) {
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

  bool RemoveAccount(String chat_id) {
    for (int i = 0; i < accounts.size(); i++) {
      if (accounts[i].GetChatId() == chat_id) {
        accounts.erase(accounts.begin() + i);
        return true;
      }
    }

    return false; 
  }
};

#endif // URHOBA_H
