using MyCRM.Data;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class ChatRepository : RepositoryBase<ChatMessage>
    {
        public ChatRepository(ApplicationDbContext repositoryContext) : base(repositoryContext) => context = repositoryContext;

        public List<ChatMessage> GetChatMessages(CRMUser sender, CRMUser recipient)
        {
            return FindByCondition(c=>(c.Sender == sender && c.Recipient == recipient) || (c.Sender == recipient && c.Recipient == sender) ).OrderBy(c=>c.Created).ToList();
        }
    }
}
