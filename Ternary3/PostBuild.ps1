param([string]$DllName);
$Ildasm = """C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\ildasm.exe"""
$CilName = "$DllName.il"
Start-Process $Ildasm -Argument "$DllName /OUT:$CilName"

# replace 
#.field public static initonly valuetype Ternary3.Trit down
#.field public static initonly valuetype Ternary3.Trit middle
#.field public static initonly valuetype Ternary3.Trit up
# by
#.field public static literal valuetype Ternary3.Trit down = uint8(0x00)
#.field public static literal valuetype Ternary3.Trit middle = uint8(0x01)
#.field public static literal valuetype Ternary3.Trit up = uint8(0x02)

$FixedCilName = "$DllName.fixed.il"
(Get-Content $CilName).	replace(".field public static initonly valuetype Ternary3.Trit down", ".field public static literal valuetype Ternary3.Trit down = uint8(0x00)").replace(".field public static initonly valuetype Ternary3.Trit middle", ".field public static literal valuetype Ternary3.Trit middle = uint8(0x01)").	replace(".field public static initonly valuetype Ternary3.Trit up", ".field public static literal valuetype Ternary3.Trit up = uint8(0x02)") | Set-Content $FixedCilName
Remove-Item $CilName

$Ilasm = """C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ilasm.exe"""
Start-Process $Ilasm -Argument "/DLL ""$FixedCilName"" /OUTPUT=""$DllName"""

Remove-Item $FixedCilName