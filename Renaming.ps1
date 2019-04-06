<#
PowerShell script to rename C# Project step-by-step: 
* Renaming Folders of AspNetCoreTemplate
* Renaming .csproj files, .sln file and all folders and files inside of default folders
* Renaming Project reference in .sln solution file
* Renaming RootNamespaces
#>

$NewProjectName = Read-Host -Prompt 'INPUT THE NEW PROJECT NAME'
$OldFolderPath = ".\AspNetCoreWebApiTemplate"
$NewFolderPath = ".\$NewProjectName"


echo "Step 1 - Renaming Default Folder of AspNetCoreWebApiTemplate"
try {
	Rename-Item -Path $OldFolderPath -newName $NewProjectName  -ErrorAction Stop
	Write-Verbose "Renamed Default Folder from $OldFolderPath to $NewFolderPath" -Verbose
} catch{
    Write-Warning "Something went wrong on Step 1"
}
echo "End Step 1"

 $OldProjectFilePath=".\$OldProjectName\$NewProjectName\AspNetCoreWebApiTemplate"
 $OldProjectName=[IO.Path]::GetFileNameWithoutExtension($OldProjectFilePath)
  
 echo "Step 2 - Renaming Projects Folders, Solution and Projects File"
 try {  
	dir -Filter "$OldProjectName*" -Recurse | 
    ren -NewName {$_.Name -replace [regex]("^"+$OldProjectName+"(\b|\B)"), $NewProjectName} -ErrorAction Stop
	Write-Verbose "Renamed Projects Folders, Solution and Projects File from '$OldProjectName' to '$NewProjectName'" -Verbose
 } catch{
    Write-Warning "Something went wrong on Step 2" -Verbose
 }
 echo "End Step 3" 

 echo "Step 4 - Renaming all Namespaces"
  try {  
	$configFiles = Get-ChildItem $NewFolderPath -rec | Where-Object {($_.Extension -eq ".cs") -or ($_.Extension -eq ".config") -or ($_.Extension -eq ".sln") -or ($_.Extension -eq ".csproj")}
	foreach ($file in $configFiles)
	{
		Write-Verbose $file.PSPath -Verbose
		(Get-Content $file.PSPath).replace($OldProjectName, $NewProjectName) | Set-Content $file.PSPath -ErrorAction Stop
	}
	Write-Verbose "Renamed Namespaces from '$OldProjectName' to '$NewProjectName'"  -Verbose
 } catch{
    Write-Warning "Something went wrong on Step 4" -Verbose
 }
 echo "End Step 4" 
 
 echo "Step 5 - Removing git folder"
  try {  
	Remove-Item .\$NewProjectName\.git -Force -Recurse
	Write-Verbose "Removing git folder"  -Verbose
 } catch{
    Write-Warning "Something went wrong on Step 5" -Verbose
 }
 echo "End Step 5" 

echo "DONE."
