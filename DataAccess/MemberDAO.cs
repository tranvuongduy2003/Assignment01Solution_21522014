using BusinessObject;

namespace DataAccess;

public class MemberDAO
{
    public static List<Member> GetMembers()
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    return context.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Member FindMember(int memId)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    return context.Members.SingleOrDefault(p => p.MemberId == memId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveMember(Member member)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMember(Member member)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteMember(Member member)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Members.Remove(context.Members.SingleOrDefault(p => p.MemberId == member.MemberId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
}