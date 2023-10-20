using BusinessObject;
using DataAccess;
using Repositories.Contracts;

namespace Repositories;

public class MemberRepository : IMemberRepository
{
    public void DeleteMember(Member member) => MemberDAO.DeleteMember(member);

    public Member GetMember(int id) => MemberDAO.FindMember(id);

    public List<Member> GetMembers() => MemberDAO.GetMembers();

    public void SaveMember(Member member) => MemberDAO.SaveMember(member);

    public void UpdateMember(Member member) => MemberDAO.UpdateMember(member);
}