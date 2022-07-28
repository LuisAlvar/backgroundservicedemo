echo "Set-Location"
$RootFolderPath = Get-Location 
$PublishDLLPath = "app/publish/"
$TargetDLL = "BackgroundServiceDemo.exe"
$FullPath = join-path -path $RootFolderPath -childpath $PublishDLLPath
$FullPath = ($FullPath + $TargetDLL)
sc.exe create ".NET Joke Service" binpath=$FullPath
# powershell -executionpolicy bypass -File .\CreateWindowsService.ps1 <-- how you execute the script