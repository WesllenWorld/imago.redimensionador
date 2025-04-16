# Redimensionador de Imagens em C#

Este projeto é um redimensionador automático de imagens usando C#. Ele monitora uma pasta chamada `Arquivos_Entrada` e, sempre que uma nova imagem for adicionada, ela será redimensionada para três tamanhos diferentes (200px, 500px e 1000px de altura). As versões redimensionadas são salvas em `Arquivos_Redimensionado`, e também copiadas para a pasta `Arquivos_Finalizados`.

## 📁 Estrutura de Pastas

O programa cria automaticamente três pastas no diretório de execução:

- `Arquivos_Entrada`: onde você deve colocar as imagens originais.
- `Arquivos_Redimensionado`: onde ficarão as imagens redimensionadas.
- `Arquivos_Finalizados`: cópias das imagens redimensionadas, organizadas por tamanho.

## ▶️ Como Usar

1. Compile o projeto com o .NET:
   ```bash
   dotnet build
   ```
2. Execute:
```bash
   dotnet run
   ```
3. Coloque suas imagens (JPEG, PNG, etc) dentro da pasta Arquivos_Entrada (gerada em bin/Debug/net8.0/ ou pasta equivalente ao executar).

4. O programa vai detectar automaticamente e redimensionar as imagens, salvando nas outras duas pastas.

