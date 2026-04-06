// Aluno: Lucas Alves Oliveira
// Disciplina: IHC e UX
// Exercício: Lista 02 - Terminal de Suporte Proativo

using System;

class Program
{
    static void Main(string[] args)
    {

        while (true){
            Console.Clear();
            Console.WriteLine("STATUS DO SISTEMA : [OPERACIONAL]");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("COMANDOS DISPONÍVEIS:");
            Console.WriteLine("> [PING] - Testar conexão");
            Console.WriteLine("> [RESET] - Reiniciar servidor (Crítico)");
            Console.WriteLine("> [HELP] - Ajuda");
            Console.WriteLine("> [SAIR] - Fechar terminal");
            Console.WriteLine("Digite um comando:");

            
            string comando = (Console.ReadLine() ?? "").ToUpper();
            
            switch (comando){
                case "PING":
                    ExecutarPing();
                    break;

                case "RESET":
                    Reset();
                    break;

                case "HELP":
                    ExibirAjuda();
                    break;

                case "SAIR":
                    Environment.Exit(0);
                    break;

                default:
                    NotificarErro("Comando não reconhecido. Digite HELP para ver a lista.");
                    break;
            }
        }
        
    }

    static void ExecutarPing() 
    {
        Console.Clear();
        Console.WriteLine("=== DIAGNÓSTICO DE REDE ===");
        Console.WriteLine("Formato esperado: 192.168.0.1 (Somente números e pontos)");
        Console.Write("Digite o IP de destino: ");

        string ip = Console.ReadLine();
        System.Net.IPAddress enderecoIp;

        bool ipValido = System.Net.IPAddress.TryParse(ip, out enderecoIp);

        if (!ipValido)
        {
            NotificarErro("IP Inválido! Certifique-se de usar o formato correto(ex: 127.0.0.1).");
            return;
        }

        Console.WriteLine($"\n[IHC] Enviando pacotes para {ip}...");
        System.Threading.Thread.Sleep(2000);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Resposta recebida com sucesso! Latência: 15ms.");
        Console.ResetColor();

        Console.ReadKey();
    }

    static void NotificarErro(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Console.ReadKey();
    }

    static void ExibirAjuda()
    {
        Console.Clear();
        Console.WriteLine("=== CENTRAL DE AJUDA ===");
        Console.WriteLine("- PING: Verifica se um servidor está respondendo.");
        Console.WriteLine("- RESET: Desliga e liga o servidor (Uso restrito).");
        Console.WriteLine("- SAIR: Encerra a sessão atual com segurança.");
        Console.WriteLine("\nPressione qualquer tecla para retornar.");
        Console.ReadKey();
    }

    static void Reset()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("!!! AVISO DE SEGURANÇA !!!");
        Console.WriteLine("Você solicitou o REBOOT do servidor central.");
        Console.WriteLine("Isso desconectará todos os usuários ativos.");
        Console.WriteLine("Tem certeza que deseja continuar? (S/N): ");
        string resposta = (Console.ReadLine() ?? "").ToUpper();
        if (resposta == "S")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reiniciando sistema...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Servidor Online.");
            Console.ResetColor();
        }
        else{
            Console.WriteLine("Operação cancelada. Voltando ao menu...");
        }

        Console.ReadKey();
        
    }

}