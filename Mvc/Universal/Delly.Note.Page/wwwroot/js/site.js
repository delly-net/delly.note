/** 上下文 */
const site = {};

/** 新增 */
site.logout = async () => {
    const response = await fetch('/app/delly/Account/Logout', {
        method: 'POST', // 指定请求方法为 POST
        headers: {
            'Content-Type': 'application/json', // 声明发送的是 JSON 数据
            // 可添加其他请求头，如 Token
            // 'Authorization': 'Bearer ' + token
        },
        body: "" // 将 JS 对象转为 JSON 字符串
    });
    if (!response.ok) {
        alert('Network response was not ok');
        console.error(res);
        return;
    }
    const res = await response.json(); // 解析响应数据为 JSON
    if (res.success !== true) {
        alert('Error: ' + res.message);
        console.error(res);
        return;
    }
    location.reload();
}