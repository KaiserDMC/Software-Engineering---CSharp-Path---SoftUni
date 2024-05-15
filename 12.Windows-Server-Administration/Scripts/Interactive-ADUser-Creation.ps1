# 
# User creation script
#

# When this is false, the script will stop execution
$addUsers = $true

While ($addUsers) {

# Inform the user about the script, request inputs
Write-Host "Please provide the following information in order to create your user account"
Write-Host ""

# Save the given inputs in variables
[string]$firstName = (Read-Host -Prompt "First Name[]")
[string]$lastName = (Read-Host -Prompt "Last Name[]")
$password = (Read-Host -AsSecureString -Prompt "Password[]")

# Create username variable
[string]$userName = "$firstName.$lastName"

# Pre-defined paths, that will later be used in the script
[string]$drive = $env:SystemDrive
[string]$sharedFolder = "$drive\Shared"
[string]$userPath = "$sharedFolder\$userName"

# Check if the user exists inside of the current AD
$checkUser = $(try {Get-ADUser $userName} catch {$null})
    # If user exists write error message and prompt user if they want to create a new user
    If ($checkUser -ne $Null) {
        Write-Host ""
        Write-Host "A User with this username already exists in the Active Directory!"

        Write-Host ""
        $choice = Read-Host "Do you want to create another user? (Yes[Y]/No[N])"

        # If choice is "No" end the script    
        If ($choice -in "N", "no") {
            Return
        }
    }
    # If user does not exist in the current AD
    Else{
        # Create new user with the provided username
            
        Try {
            New-ADUser -SamAccountName $userName -Name $userName -GivenName $firstName -Surname $lastName -AccountPassword $password -Enabled $true
        }
        Catch {
        # If an error occurs during user creation, e.g. password is not secure enough, throw error and ask for new user
            Write-Host ""
            Write-Host "There was an error upon user creation: $_"

            Write-Host ""
            $choice = Read-Host "Do you want to create another user? (Yes[Y]/No[N])"

            # If choice is "No" end the script    
            If ($choice -in "N", "no") {
                Return
            }
            # If the user wished to create a new account, remove the failed user and return to the start of the script
            Else {
                Remove-ADUser -Identity $userName -Confirm:$false
                Continue
            }
        }
        # Check if the "Shared" directory exists, this is needed if no other users were created beforehand
        # If directory exists, create user directory
        If (Test-Path -Path $sharedFolder -PathType Container) {
            Write-Host ""
            Write-Host "Shared directory exists."
            Write-Host "Creating user folder..."

            New-Item -Path $userPath -ItemType Directory
        }
        # If directory does not exist, create "Shared" location and user directory 
        Else {
            Write-Host ""
            Write-Host "Shared directory does not exist."
            Write-Host "Creating shared folder..."

            New-Item -Path $sharedFolder -ItemType Directory

            Write-Host ""
            Write-Host "Creating user folder..."

            New-Item -Path $userPath -ItemType Directory
        }

        # Ask the user if they wish to create additional users
        Write-Host ""
        $choice = Read-Host "Do you want to create another user? (Yes[Y]/No[N])"
        
        # If choice is "No" end the script
        If ($choice -in "N", "no") {
            $addUsers = $false
        }    
    }
}