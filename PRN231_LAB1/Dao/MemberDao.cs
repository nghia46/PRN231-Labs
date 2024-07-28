using BusinisseObjects;
using BusinisseObjects.Models;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Dao;

public class MemberDao
{
    private readonly AppDbContext _context = new();
    
    public async Task<IEnumerable<Member>> GetMembers()
    {
        return await _context.Members.ToListAsync();
    }
    
    public async Task<Member?> GetMemberById(string id)
    {
        return await _context.Members.FindAsync(id);
    }
    
    public async Task<Member> AddMember(Member member)
    {
        member.MemberId = Generator.IdGenerator();
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return member;
    }
    public async Task<string> DeleteMember(string id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            return "Member not found";
        }
        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
        return "Member deleted";
    }
    public async Task<Member?> UpdateMember(string id,Member member)
    {
        var memberToUpdate = await _context.Members.FindAsync(id);
        if (memberToUpdate == null)
        {
            return null;
        }
        memberToUpdate.City = member.City;
        memberToUpdate.Email = member.Email;
        memberToUpdate.City = member.City;
        memberToUpdate.CompanyName = member.CompanyName;
        memberToUpdate.Country = member.Country;
        memberToUpdate.Password = member.Password;
        
        await _context.SaveChangesAsync();
        
        return memberToUpdate;
    }
}