using BusinessObject;

namespace Repositories.Contracts;

public interface IMemberRepository
{
    void SaveMember(Member member);

    Member GetMember(int id);

    void DeleteMember(Member member);

    void UpdateMember(Member member);

    List<Member> GetMembers();
}