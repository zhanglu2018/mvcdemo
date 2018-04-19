var User = {
    Logins: function () {
        var id = $("#id").val();
        var password = $("#password").val();
        if (id == "" || id == null) {
            alert("请输入用户名");
        }
        else if (password == "" || id == password) {
            alert("请输入密码");
        }
        else {
            $.post("/UserAjax/Login",
            {
                id: id,
                password: password
            },
            function (data, status) {
                if (data == "1") {
                    window.location.href = "/Home/Main/?id=" + id + "&password=" + password + "";
                    if (window.event)
                        window.event.returnValue = false;
                    else
                        event.preventDefault();
                 
                    
                }
                else {
                    alert("用户名或密码错误！");
                    if (window.event)
                        window.event.returnValue = false;
                    else
                        event.preventDefault();
                }
            });

        }
       
    }
}
