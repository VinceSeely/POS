# POS
Dont PUSH to master ever 

git branch //view all branchs
git checkout -B <brachName> //this checkouts out a branch and if the branch does not exist yet it will create the branch
git checkout <branchName> //

// do all your work on a branch other than master 

git add <file>  // adds file speciefied to be added to the commit
git add . 		//adds all files with changes

git pull //gets updated changes
git push // push changes upstream if there is an upstream
git rebase <branchName> // puts all your work from current branch on top of the speciefied branch 



git merge-tool //if there is a mergeconflict use this it will walk you through how to use it


gitk // shows version history
git-gui // allows you to add and see what exact changes you are commiting or change a prior commit and add more files


git reset --hard // brings you back to last commit
git reset <pointInHistory> // resets to point in history
git <command> --help // command is optional gives you help on how to use git or a git command