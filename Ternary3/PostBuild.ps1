param([string]$DllName,[string]$SolutionDir,[string]$Configuration);

Write-Output "replace stuff"

# ugly hack to enable the creation of "const Trit up = 2"
# does not work well with code within the same project.
# Once we have one instance of a constant Trit (normally not allowed in c#)
# the compiler will copy this value around.

$Ildasm = """C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\ildasm.exe"""
$CilName = "$DllName.il"
Start-Process -wait $Ildasm -Argument "$DllName /OUT:$CilName"

$cil = (Get-Content -path $CilName)
#$cil = $cil.replace(".field public static initonly valuetype Ternary3.Trit down", ".field public static literal valuetype Ternary3.Trit down = int8(-1)")
#$cil = $cil.replace(".field public static initonly valuetype Ternary3.Trit middle", ".field public static literal valuetype Ternary3.Trit middle = int8(0)")
#$cil = $cil.replace(".field public static initonly valuetype Ternary3.Trit up", ".field public static literal valuetype Ternary3.Trit up = int8(1)")
#$cil = $cil.replace("ldsfld valuetype Ternary3.Trit Ternary3.Trit::Down", "ldc_I4_M1");
#$cil = $cil.replace("ldsfld valuetype Ternary3.Trit Ternary3.Trit::Middle", "ldc_I4_0");
#$cil = $cil.replace("ldsfld valuetype Ternary3.Trit Ternary3.Trit::Up", "ldc_I4_1");
$FixedCilName = "$DllName.fixed.il"
Set-Content $FixedCilName -value $cil

Remove-Item $CilName
Remove-Item $DllName

Write-Output "compile"
$Ilasm = """C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ilasm.exe"""
Start-Process -wait $Ilasm -Argument "/DLL ""$FixedCilName"" /OUTPUT=""$DllName"""

Remove-Item $FixedCilName

#Copy-Item -Force -Path $DllName -Destination $DllName/../../../../lib/Release/net6.0/
#$(SolutionDir)Ternary3\lib\$(Configuration)\net6.0\Ternary3.dll
