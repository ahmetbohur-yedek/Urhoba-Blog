#ifndef URHOBA_H
#define URHOBA_H

#include <Arduino.h>
#include <vector>
#include <WiFiClient.h>
#include <IPAddress.h>

class UrhobaServer{
    private:
        String serverName;
        IPAddress targetIP;
        int targetPort;
    public:
        UrhobaServer(String server_name, IPAddress ip_address, int port);
        IPAddress getTargetIP() const;
        int getTargetPort() const;
        String getServerName() const;
        bool getServerStatus() const;
        void setServerName(String server_name);
        void setServerPort(int port);
        void setServerIp(IPAddress ip_address);
};

class Account{
    private:
        String chatId;
        std::vector<UrhobaServer> servers;
    public:
        Account(String chat_id);
        String getChatId();
        bool addServer(String server_name, IPAddress ip_address, int port);
        bool removeServer(int server_index);
        UrhobaServer getServer(int server_index);
        UrhobaServer& getServerRef(int server_index);
        std::vector<UrhobaServer> getAllServers();
        std::vector<UrhobaServer> getAllServersConst() const;
};  

class AccountManager{
    private:
        std::vector<Account> accounts;
    public:
        bool addAccount(String chat_id);
        bool removeAccount(String chat_id);
        Account* findAccount(String chat_id);
        std::vector<Account> getAccounts();
};

#endif