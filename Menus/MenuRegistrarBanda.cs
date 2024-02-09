using OpenAI_API;
using ScreenSound.Modelos;
namespace ScreenSound.Menus;

	internal class MenuRegistrarBanda : Menu
{ 
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        //Criar nova conta no OpenIA Chat GPT cadastrando novo número.
        //Crie uma API Key
        var client = new OpenAIAPI("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");

        var chat = client.Chat.CreateConversation();

        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 parágrafo, adote um estilo informal.");

        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.Resumo = resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

