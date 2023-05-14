using Microsoft.AspNetCore.Mvc;
using NoteNote.DataContext;
using NoteNote.Models;
using NoteNote.ViewModel;

namespace NoteNote.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // id 비밀번호 - 필수 
            if(ModelState.IsValid)
            {
                // 오픈 커넥션을 열고 닫기 위해서 using 사용
                // 바로 밑의 줄 db를 열고 닫겠다
                // 사용자 입력값을 검증 , 정상적인 유저인지
                using (var db = new NoteNoteContext())
                {
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId)
                        && u.UserPassword.Equals(model.UserPassword ));
                    if (user != null)
                    {
                        return RedirectToAction("LoginSuccess", "Home");

                    }
                    
                    // db 에서 같은 유저가 있는지 db 에서 조회 한다 
                    // linkq 를 통해서 조회 
                    // 여기서 사용하는건 메서드 체인 방식 ,, 메서드가 연속적으로
                    //var user = db.Users.FirstOrDefault(u=>u.UserId.Equals(model.UserId)); // <- db 에서 제일 처음놈

                    // 자바에서와 마찬가지로 == 이런 표현은 메모리 누수가 발생 
                    // 이유 userid 는 db 에서 받아온것과 model 의 UserId 를 비교하게 되면 
                    // 오른쪽의 것 model.UserId 는  새로운 스트링 객체로 선언한게 된것 -> 메모리 누수
                    //var user = db.Users
                    //    .FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);



                    //var user = db.Users
                    //.FirstOrDefault
                    //(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword);
                    //    var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId));

                    //if (user == null)
                    //{
                    //    //로그인 실패
                    //    // 빈값,
                    //    //사용자 ID 자체가 회원가입 X 인 경우 
                    //    //ModelState.AddModelError(string.Empty,"사용자 ID 혹은 비밀번호가 올바르지 않습니다");
                    //    ModelState.AddModelError(string.Empty,"사용자 id 가 존재 x")
                    //} 
                    //else
                    //{
                    //    //로그인 성공 페이지로 redirect
                    //    return RedirectToAction("Home", "LoginSuccess");
                    //}



                }
                ModelState.AddModelError(string.Empty, "아이디 또는 비번 실패");

            }

            return View(model);
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)

        {
            if(ModelState.IsValid)
            {
                using (var db = new NoteNoteContext())
                { 
                    db.Users.Add(model);
                    db.SaveChanges();
                    //db.Users.Add(model);

                }
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
    }
}
