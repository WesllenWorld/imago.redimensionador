using System.Drawing;

Console.WriteLine("Processo de redimensionamento iniciado.");

Thread thread = new Thread(Redimensionar);
thread.Start();
//Redimensionar();
static void Redimensionar()
{
    //Pastas_Setup();
    string entrada = "Arquivos_Entrada";
    if (!Directory.Exists(entrada))
    {
        Directory.CreateDirectory(entrada);
    }
    string redimensionados = "Arquivos_Redimensionado";
    if (!Directory.Exists(redimensionados))
    {
        Directory.CreateDirectory(redimensionados);
    }
    string finalizados = "Arquivos_Finalizados";
    if (!Directory.Exists(finalizados))
    {
        Directory.CreateDirectory(finalizados);
    }




    while (true)
    {
        //verificar a pasta entrada
        //se houver algum arquivo, redimensionar

        var arquivosEntrada = Directory.EnumerateFiles(entrada);

        //ler o tamanho que irá redimensionar
        int novaAltura = 200;

        //Instanciar FileStream e FileInfo
        FileStream fs;
        FileInfo fileInfo;

        foreach (var arquivo in arquivosEntrada)
        {
            //Console.WriteLine(arquivo);
            fs = new FileStream(arquivo, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            fileInfo = new FileInfo(arquivo);

            string caminho = Environment.CurrentDirectory + @"\" + redimensionados + @"\" + DateTime.Now.Millisecond.ToString() +"_"+ fileInfo.Name;
            //redimensionar e copiar os arquivos para a pasta redimensionados
            Redimensionador(Image.FromStream(fs), novaAltura, caminho);
            
            //é importante descartar (fechar) o que estiver na memória
            //usando fs.Close(). Similar ao que é feito em Java.
            fs.Close();

            //em seguida, mover de entrada para finalizados
            string caminhoFinalizado = Environment.CurrentDirectory + @"\" + finalizados + @"\" + DateTime.Now.Millisecond.ToString() + fileInfo.Name;
            fileInfo.MoveTo(caminhoFinalizado);
            

        }
        Thread.Sleep(new TimeSpan(0, 0, 3));
    }

}

/// <summary>
///
/// </summary>
/// <param name="img">Imagem a ser redimensionada</param>
/// <param name="tamanho">Tamanho desejado</param>
/// <param name="caminho">Caminho de arquivo onde será gravado o resultado do redimensionamento</param>
/// <returns></returns>
static void Redimensionador(Image img, int tamanho, string caminho)
{
    double aspectRatio = (double)tamanho / img.Height;
    int novaLargura = (int)(img.Width * aspectRatio);
    int novaAltura = (int)(img.Height * aspectRatio);
    
    Bitmap novaImagem = new Bitmap(novaLargura, novaAltura);
    using(Graphics g = Graphics.FromImage(novaImagem))
    {
        g.DrawImage(img, 0, 0, novaLargura, novaAltura);
    }
    novaImagem.Save(caminho);
    novaImagem.Dispose();
}

/*static void Pastas_Setup(){
    string entrada = "Arquivos_Entrada";
    if (!Directory.Exists(entrada))
    {
        Directory.CreateDirectory(entrada);
    }
    string redimensionado = "Arquivos_Redimensionado";
    if (!Directory.Exists(redimensionado))
    {
        Directory.CreateDirectory(redimensionado);
    }
    string finalizados = "Arquivos_Finalizados";
    if (!Directory.Exists(finalizados))
    {
        Directory.CreateDirectory(finalizados);
    }
}*/