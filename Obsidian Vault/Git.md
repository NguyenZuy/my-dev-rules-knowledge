Some of these common useful for multiple account with SSH keys
- https://gist.github.com/jexchan/2351996
- `git config --list` for view cur config
- `git config --local --list` to view local config of repo
- `git remote set-url(or add) origin git@github.com-nguyenduygamedev:NguyenZuy/tenebrous-recursion.git` for change url to use ssh
- sometime, cannot clone from the git through ssh because not have permission for key ssh use `chmod 600 ~/.ssh/nguyenduygamedev/id_rsa` 
- `git restore .` to discard all unstaged changes
- `git restore --staged <file>` to discard all staged changes
- `git clean -fd` to discard all file untracked
- `git remote -v` to check remote status
- clone `git clone git@github.com-nguyenduygamedev:NguyenZuy/zuy-workspace.git`
- delete branch local `git branch -d <branch-name>` (force delete `-D instead -d`)
- delete remote branch `git push origin --delete <branch-name>`
- check branch remote `git branch -r`








`