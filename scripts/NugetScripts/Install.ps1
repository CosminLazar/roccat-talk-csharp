#The Roccat-Talk nuget package depends on the unmanaged talkfx-c.dll files
#While the files are included in the nuget package and added to the VS solution, they are not being copied to the output directory
#This script edits the project file and marks the talkfx-c.dll files to always be copied to the output directory
param($installPath, $toolsPath, $package, $project)

$x86TalkFX = $project.ProjectItems.Item("CroccatTalkWrapper").ProjectItems.Item("win32-x86").ProjectItems.Item("talkfx-c.dll");
$x86TalkFX.Properties.Item("CopyToOutputDirectory").Value = [int]2;

$x64TalkFX = $project.ProjectItems.Item("CroccatTalkWrapper").ProjectItems.Item("win32-x86-64").ProjectItems.Item("talkfx-c.dll");
$x64TalkFX.Properties.Item("CopyToOutputDirectory").Value = [int]2;
