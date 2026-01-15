/** 上下文 */
const ctx = {};

/** 保存 */
ctx.save = async (data) => {
    if (data.id === "") {
        return await ctx.insert(data);
    }
    await ctx.update(data);
    return data;
};

/** 新增 */
ctx.insert = async (data) => {
    const response = await fetch('/app/delly/Note/Insert', {
        method: 'POST', // 指定请求方法为 POST
        headers: {
            'Content-Type': 'application/json', // 声明发送的是 JSON 数据
            // 可添加其他请求头，如 Token
            // 'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(data) // 将 JS 对象转为 JSON 字符串
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
    alert("保存成功");
    return res.data;
}

/** 更新 */
ctx.update = async (data) => {
    const response = await fetch('/app/delly/Note/Update', {
        method: 'PUT', // 指定请求方法为 PUT
        headers: {
            'Content-Type': 'application/json', // 声明发送的是 JSON 数据
            // 可添加其他请求头，如 Token
            // 'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(data) // 将 JS 对象转为 JSON 字符串
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
    alert("保存成功");
}

