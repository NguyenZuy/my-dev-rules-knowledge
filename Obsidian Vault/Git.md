Use for multiple account with SSH keys
- https://gist.github.com/jexchan/2351996
- `git config --list` for view cur config
- `git config --local --list` to view local config of repo
- `git remote set-url origin git@github.com-nguyenduygamedev:NguyenZuy/tenebrous-recursion.git` for change url to use ssh
- sometime, cannot clone from the git through ssh because not have permission for key ssh use `chmod 600 ~/.ssh/nguyenduygamedev/id_rsa` 