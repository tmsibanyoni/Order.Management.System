Executing step: Writing configuration file

Saving my.ini configuration file...
Saved my.ini configuration file.
Completed execution of step: Writing configuration file

Executing step: Updating Windows Firewall rules

Adding a Windows Firewall rule for MySQL93 on port 3306.
Attempting to add a Windows Firewall rule with command: netsh.exe advfirewall firewall add rule name="Port 3306" protocol=TCP localport=3306 dir=in action=allow
Ok.


Successfully added the Windows Firewall rule.
Adding a Windows Firewall rule for MySQL93 on port 33060.
Attempting to add a Windows Firewall rule with command: netsh.exe advfirewall firewall add rule name="Port 33060" protocol=TCP localport=33060 dir=in action=allow
Ok.


Successfully added the Windows Firewall rule.
Completed execution of step: Updating Windows Firewall rules

Executing step: Adjusting Windows service

Attempting to grant the required filesystem permissions to the 'NT AUTHORITY\NetworkService' account.
Granted permissions to the data directory.
Granted permissions to the install directory.
Adding new service
New service added
Completed execution of step: Adjusting Windows service

Executing step: Initializing database (may take a long time)

Attempting to run MySQL Server with --initialize-insecure option...
Starting process for MySQL Server 9.3.0...
Starting process with command: C:\Program Files\MySQL\MySQL Server 9.3\bin\mysqld.exe --defaults-file="C:\ProgramData\MySQL\MySQL Server 9.3\my.ini" --console --initialize-insecure=on --lower-case-table-names=1...
MySQL Server Initialization - start.
C:\Program Files\MySQL\MySQL Server 9.3\bin\mysqld.exe (mysqld 9.3.0) initializing of server in progress as process 26000
InnoDB initialization has started.
InnoDB initialization has ended.
root@localhost is created with an empty password ! Please consider switching off the --initialize-insecure option.
MySQL Server Initialization - end.
Process for mysqld, with ID 26000, was run successfully and exited with code 0.
Successfully started process for MySQL Server 9.3.0.
MySQL Server 9.3.0 intialized the database successfully.
Completed execution of step: Initializing database (may take a long time)

Executing step: Updating permissions for the data folder and related server files

Attempting to update the permissions for the data folder and related server files...
Inherited permissions have been converted to explicit permissions.
Full control permissions granted to: NETWORK SERVICE.
Full control permissions granted to: Administrators.
Full control permissions granted to: CREATOR OWNER.
Full control permissions granted to: SYSTEM.
Access to the data directory is removed for the users group.
Permissions for the data folder and related server files are updated correctly.
Completed execution of step: Updating permissions for the data folder and related server files

Executing step: Starting the server

Attempting to start service MySQL93...
MySQL Server - start.
C:\Program Files\MySQL\MySQL Server 9.3\bin\mysqld.exe (mysqld 9.3.0) starting as process 28620
InnoDB initialization has sta
rted.
InnoDB initialization has ended.
CA certificate ca.pem is self signed.
Channel mysql_main configured to support TLS. Encrypted connections are now supported for this channel.
X Plugin ready for connections. Bind-address: '::' port: 33060
C:\Program Files\MySQL\MySQL Server 9.3\bin\mysqld.exe: ready for connections. Version: '9.3.0'  socket: ''  port: 3306  MySQL Community Server - GPL.
Successfully started service MySQL93.
Waiting until a connection to MySQL Server 9.3.0 can be established (with a maximum of 10 attempts)...
Retry 1: Attempting to connect to Mysql@localhost:3306 with user root with no password...
Successfully connected to MySQL Server 9.3.0.
Completed execution of step: Starting the server

Executing step: Applying security settings

Attempting to update security settings.
Updated security settings.
Completed execution of step: Applying security settings

Executing step: Updating the Start menu link

Attempting to verify command-line client shortcut.
Verified command-line client shortcut.
Verified command-line client shortcut.
Completed execution of step: Updating the Start menu link

Executing step: Updating example databases

Updating example databases...
Completed execution of step: Updating example databases

