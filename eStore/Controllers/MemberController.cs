using System.Net.Http.Headers;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eStore.Controllers;

public class MemberController : Controller
{
    private readonly HttpClient client = null;
    private string MemberApiUrl = "";

    public MemberController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        MemberApiUrl = "https://localhost:7141/member";
    }

    public async Task<IActionResult> Index()
    {
        HttpResponseMessage memberResponse = await client.GetAsync(MemberApiUrl);
        List<Member>? listMembers = new List<Member>();
        if (memberResponse.StatusCode == System.Net.HttpStatusCode.OK)
        {
            listMembers = await memberResponse.Content.ReadFromJsonAsync<List<Member>>();
        }

        return View(listMembers);
    }

    public async Task<IActionResult> Details(int id)
    {
        HttpResponseMessage memberResponse = await client.GetAsync(MemberApiUrl + $"/{id}");
        Member? member = new Member();
        if (memberResponse.StatusCode == System.Net.HttpStatusCode.OK)
        {
            member = await memberResponse.Content.ReadFromJsonAsync<Member>();
        }
        
		return View(member);
    }

    public async Task<ActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Member p)
    {
        HttpResponseMessage response =
            await client.PostAsJsonAsync(MemberApiUrl, p);
        if (ModelState.IsValid)
        {
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        }

        return Redirect("Create");
    }

    public async Task<ActionResult> Edit(int id)
    {
        HttpResponseMessage memberResponse = await client.GetAsync(MemberApiUrl + $"/{id}");
        Member member = new Member();
        if (memberResponse.StatusCode == System.Net.HttpStatusCode.OK)
        {
            member = memberResponse.Content.ReadFromJsonAsync<Member>().Result;
        }

        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, Member p)
    {
        if (ModelState.IsValid)
        {
            await client.PutAsJsonAsync(MemberApiUrl + $"/{p.MemberId}", p);
            return RedirectToAction("Index");
        }

        return View(p);
    }

    public async Task<ActionResult> Delete(int id)
    {
        await client.DeleteAsync(MemberApiUrl + $"/{id}");
        return RedirectToAction("Index");
    }
}