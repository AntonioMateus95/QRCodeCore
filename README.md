# QRCodeCore
A simple library written in dotnet core which generates a QR Code

## Usage
`using QRCodeCore;`

`using (FileStream file = new FileStream(Path.Combine(directory, "Teste.png"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
{
    file.GenerateQRCode("<url>");
}`
