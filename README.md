# simple-deploy-tool

Script works with tree folders:
1. Source folder containing deployable file tree.
2. Application folder with your project files.
3. Backup folder.

Firstly script reads file tree from source folder, searches for analog files in application folder and tries to do a backup. 
A new backup folder is created for every deployment. 
Finally application files are replaced with source folder file. 

----------

Script reads from config.txt file. It should be created near .exe file.
- First line must contain Source folder path.
- Secound line must contain Application folder path.
- Third line must contain Backup folder path.

Example of config.txt file:
```
C:\Users\pc\Project\Source
C:\Users\pc\Project\Live
C:\Users\pc\Project\Backup
```