/**  * Created by sfrost on 15-8-31. 
 * 所有函数，虽然返回了false，但前台页面好像不起作用
 * 所以，建议前台页面做if !isset判断，并返回 return false
 * 以实现为false时中断程序执行操作
 */

/**
 * 检查所有设置了title参数的控件为必填，并以title内容为提示信息
 * @returns {boolean}
 */

function xyr_CheckInput() {
    //var inputs = $("input[name!='']"); //选择所有name属性不为空的input
    //var inputs = $("input[name^='mf_']"); //选择所有name属性以mf_开头的 input
    var inputs = $("input[title]"); //选择所有设置了title属性的控件（设置title!=''好像不行）
    if (inputs != null && inputs.length > 0) {
        for (var i = 0; i < inputs.length; i++) {
            if ($(inputs[i]).val() == null || $(inputs[i]).val().trim() == "") {  //val().trim()只支持IE9+
                alert('请填写或选择：' + $(inputs[i]).attr('title'));
                $(inputs[i]).focus();
                return false;
            }
        }
        return true;
    }
}
/**
 * （暂时不能使用）判断是否为数字
 * 可指定长度限制
 * @param n
 * @returns {boolean}
 */
function xyr_IsNumber(n) {
    var t = /^[0-9]$/;
    //var t=/^[0-9]{5}$/;  //长度为5位
    return t.test(n);
}

/**
 * 传入form控件id，判断是否为手机号码
 * @param inputId
 * @returns {boolean}
 */
//手机号码判断
function xyr_IsMobile(inputId) {
    if (!$('#' + inputId).val().match(/^1[358][0-9]{9}$/)) {
        alert("手机号码格式不正确！");
        $('#' + inputId).focus();
        return false;
    }
    return true;
}


/**
 * 生成指定长度的随机数，
 * math.floor（四舍五舍），取整，返回数含0
 * math.ceil（返回大于或等于并与x接近的整数，x为正则入，x为负则舍）
 * math.round（四舍五入），取整
 * @param n
 * @returns {string}
 */
//用ceil（入）就不会有0，用floor（舍）就会产生0
function xyr_GetRandom(n) {
    var rn = "";
    for (var i = 1; i <= n; i++) {
        rn += Math.ceil(Math.random() * n);
    }
    //return Math.random() * n;
    return rn;
    //return Math.floor(Math.random());
}