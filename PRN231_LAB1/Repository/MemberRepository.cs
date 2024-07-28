using BusinisseObjects.Models;
using Dao;

namespace Repositoy;

public class MemberRepository(MemberDao memberDao) : IGenericRepository<Member>
{
    private MemberDao MemberDao { get; } = memberDao;

    public async Task<Member?> GetByIdAsync(string id)
    {
        return await MemberDao.GetMemberById(id);
    }

    public async Task<IEnumerable<Member>?> GetAllAsync()
    {
        return await MemberDao.GetMembers();
    }

    public async Task<Member?> AddAsync(Member entity)
    {
        return await MemberDao.AddMember(entity);
    }

    public async Task<Member?> UpdateAsync(string id, Member entity)
    {
        return await MemberDao.UpdateMember(id, entity);
    }

    public async Task<string> DeleteAsync(string id)
    {
        return await MemberDao.DeleteMember(id);
    }
}