- Error with Unity Editor -> Set to Vulkan.
- `inxi -Fxz`  or `inxi -Fxxxrz` to view the stats.
- Work with `screen`:
	- `screen -ls` to list all screen
	- `screen -S PID -X quit` to close screen depend PID
	- `screen` to create new screen 
- Setup new VPS Unbutu:
	- Firewall
- `sudo update-alternatives --config java` to modify default jdk
- Create the symbolic link:
	- Create a .sh file and typing into ```
	  #!/bin/bash 
	  nohup /opt/smartgit/bin/smartgit.sh > /dev/null 2>&1 &```
	- `ln -s /opt/smartgit/bin/smartgit_run.sh ~/bin/smartgit` to create link
	- `chmod +x ~/bin/smartgit` to grant permission 
	- `export PATH="$HOME/bin:$PATH"`
	- `source ~/.bashrc`
- Startup App Manager:
	- `systemctl list-unit-files --type=service | grep enabled` to view all service in startup
	- `sudo systemctl disable service_name.service`
	- `sudo systemctl enable service_name.service`
- Run Auto_rename:
	- `auto_rename.sh /home/nguyenzuy/Music/ png`
- Force reboot:
	  - `hold alt + prt sc + r e i s u b`
- Find ip: 
	- `ip a`

# Run .sh file in anywhere
### Option 1: Add the script to the PATH
- **Move or copy the script to `/usr/local/bin`** (a common directory in `$PATH`):
	`sudo cp ~/Projects/linux-bash/rename_multiple_files/auto_rename.sh /usr/local/bin/`
- Make sure it's executable:
	`sudo chmod +x /usr/local/bin/auto_rename.sh`
- Now you can run it from anywhere:
	`auto_rename.sh /home/nguyenzuy/Music/ png`
### Option 2: Create an Alias
- **Open your shell configuration file** (`~/.bashrc` or `~/.bash_profile`):
  `nano ~/.bashrc`
- **Add an alias** to the bottom of the file:
  `alias rename_files='~/Projects/linux-bash/rename_multiple_files/auto_rename.sh'`
- Reload your `.bashrc` file:
  `source ~/.bashrc`
- Now you can run the script using the alias:
  `rename_files /home/nguyenzuy/Music/ png`
### Option 3: Create a Symbolic Link
- Create a symbolic link:
  `sudo ln -s ~/Projects/linux-bash/rename_multiple_files/auto_rename.sh /usr/local/bin/auto_rename`
- Ensure the script is executable:
  `chmod +x ~/Projects/linux-bash/rename_multiple_files/auto_rename.sh`
- Now you can run the script using the symlink:
  `auto_rename /home/nguyenzuy/Music/ png
# Change Directories
- Go to `cd /path/to/directory`
- Go home `cd` or `cd ~`
- Go up one directory  `cd ..`