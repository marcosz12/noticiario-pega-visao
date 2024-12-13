using Noticiario.Data;
using Noticiario.Models;
using System.Linq;

namespace Noticiario.Services.Seeding
{
    public class SeedingService
    {
        private readonly NewsContext _context;
        public SeedingService(NewsContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (_context.News.Any())
            {
                return;
            }

            NewsItem n1 = new NewsItem(1, "Campeão da Libertadores 2025", "Esportes", new DateTime(2024, 12, 12), "Palhoça");
            NewsItem n2 = new NewsItem(2, "Tecnologia 2024: O que esperar?", "Tecnologia", new DateTime(2024, 11, 15), "São Paulo");
            NewsItem n3 = new NewsItem(3, "Eleições 2024: O que está em jogo?", "Política", new DateTime(2024, 10, 10), "Brasília");
            NewsItem n4 = new NewsItem(4, "Brasil vence Copa do Mundo Sub-20", "Esportes", new DateTime(2024, 9, 5), "Rio de Janeiro");
            NewsItem n5 = new NewsItem(5, "Inovações em energias renováveis para 2025", "Tecnologia", new DateTime(2024, 8, 20), "Porto Alegre");
            NewsItem n6 = new NewsItem(6, "Entrevista exclusiva com o presidente", "Política", new DateTime(2024, 7, 15), "Brasília");
            NewsItem n7 = new NewsItem(7, "Dicas para otimizar seu trabalho remoto", "Carreira", new DateTime(2024, 6, 10), "Florianópolis");
            NewsItem n8 = new NewsItem(8, "Como o clima está impactando a agricultura no Brasil", "Economia", new DateTime(2024, 5, 25), "Campinas");
            NewsItem n9 = new NewsItem(9, "A nova era dos carros elétricos", "Tecnologia", new DateTime(2024, 4, 15), "Curitiba");
            NewsItem n10 = new NewsItem(10, "Desafios políticos no cenário brasileiro", "Política", new DateTime(2024, 3, 10), "Brasília");
            NewsItem n11 = new NewsItem(11, "Inovações em tratamentos médicos para 2025", "Saúde", new DateTime(2024, 2, 5), "São Paulo");
            NewsItem n12 = new NewsItem(12, "Como o mercado de trabalho está se transformando com a inteligência artificial", "Carreira", new DateTime(2024, 1, 20), "Florianópolis");
            NewsItem n13 = new NewsItem(13, "O impacto da pandemia no setor de turismo", "Economia", new DateTime(2023, 12, 15), "Rio de Janeiro");
            NewsItem n14 = new NewsItem(14, "Avanços na pesquisa sobre energia solar", "Tecnologia", new DateTime(2023, 11, 10), "Porto Alegre");
            NewsItem n15 = new NewsItem(15, "Crescimento das startups no Brasil", "Economia", new DateTime(2023, 10, 5), "São Paulo");
            NewsItem n16 = new NewsItem(16, "Neymar é a nova contratação do Corinthians", "Esportes", new DateTime(2024, 12, 1), "São Paulo");
            NewsItem n17 = new NewsItem(17, "Palmeiras rebaixado para a Série B", "Esportes", new DateTime(2024, 11, 25), "São Paulo");
            NewsItem n18 = new NewsItem(18, "Flamengo é derrotado pelo Vasco por 10x0", "Esportes", new DateTime(2024, 11, 5), "Rio de Janeiro");
            NewsItem n19 = new NewsItem(19, "Grêmio vence clássico gaúcho e se aproxima do título", "Esportes", new DateTime(2024, 10, 15), "Porto Alegre");
            NewsItem n20 = new NewsItem(20, "São Paulo contrata Ribamar para a temporada 2025", "Esportes", new DateTime(2024, 9, 28), "São Paulo");

            await _context.News.AddRangeAsync(n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20);

            await _context.SaveChangesAsync();
        }
    }
}
