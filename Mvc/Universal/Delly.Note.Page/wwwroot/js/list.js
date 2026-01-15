/** 上下文 */
const ctx = {};

/** 删除 */
ctx.delete = async (id, title) => {
    if (confirm(`确定要删除笔记 ${title} 吗？`) !== true) { return; }
    const response = await fetch(`/app/delly/Note/Delete?id=${id}`, {
        method: 'DELETE', // 指定请求方法为 DELETE
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
    alert("删除成功");
    location.reload();
}

