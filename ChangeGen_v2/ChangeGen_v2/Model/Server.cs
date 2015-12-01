﻿using System.Threading;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    // This class represents the Server object, which used to store information about remote machine, parameters and current state of DDT
    class Server
    {
        public CancellationTokenSource _cts;                        // Cancelation token to cancel DDT operations on server
        public Task _task;                                          // Used to create separate async task for each server
        public string _ip;                                          // Server ip address
        public string _displayname;                                 // Server display name on Core if available
        public string _repository;                                  // Server repository on Core if available
        public string _username;                                    // Server username for connection
        public string _password;                                    // Server password for connection
        public int _fileSize;                                       // in MB, Size of file to generate via DDT on Server
        public int _compression;                                    // in percents, Compression setting for DDT
        public int _interval;                                       // in minutes, How often generate data on server, i.e. each 60 minutes
        private string _filepath;                                   // Path on server where file will be generated by DDT
        public DDTStatus _ddtStatus = DDTStatus.Stopped;            // Current status of DDT on server


        // This construcor is using when creating new instance using data from Core.
        public Server(string ip, string displayname, string repository)
        {
            _ip = ip;
            _displayname = displayname;
            _repository = repository;
        }

        // Property to set and access _filepath field
        public string FilePath
        {
            get
            {
                return _filepath;
            }
            set
            {
                if (!value.EndsWith("\\"))  // Check if value in tb_Path is end with '\' symbol
                {
                    value += "\\";  
                }
                _filepath = value;
            }
        }


        // Enumaraion of possible status for DDT tool on server
        public enum DDTStatus
        {
            Running,
            Stopped,
            Failed
        }

        // Method used to run DDT on server side
        public void Runddt()
        {
            DDT.Runddtremotely(_ip, _username, _password, _filepath, _fileSize, _compression, _interval, _cts.Token);
        }
    }
}
