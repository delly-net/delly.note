// 完整翻译数据
const translations = {
    zh: {
        name: "中文",
        home: "首页",
        products: "产品",
        about: "关于",
        contact: "联系",
        search: "搜索产品"
    },
    en: {
        name: "English",
        home: "Home",
        products: "Products",
        about: "About",
        contact: "Contact",
        search: "Search products"
    },
    ar: {
        name: "الصفحة الرئيسية",
        home: "الصفحة الرئيسية",
        products: "المنتجات",
        about: "معلومات",
        contact: "اتصل",
        search: "ابحث عن المنتجات"
    },
    ru: {
        name: "Главная",
        home: "Главная",
        products: "Продукты",
        about: "О нас",
        contact: "Контакты",
        search: "Поиск товаров"
    },
    fa: {
        name: "خانه",
        home: "خانه",
        products: "محصولات",
        about: "درباره",
        contact: "تماس",
        search: "جستجوی محصولات"
    }
};

// 语言切换功能
document.querySelectorAll('.language-dropdown a').forEach(link => {
    link.addEventListener('click', (e) => {
        e.preventDefault();
        const lang = e.target.dataset.lang;
        //setLanguage(lang);
        const query = getUrlParams(location.href);
        query.lang = lang;
        location.href = getQueryUrl(query);
    });
});

// 获取带查询的地址
function getQueryUrl(query, path) {
    let url = path ?? location.pathname;
    let isFirst = true;
    Object.keys(query).forEach((key) => {
        const value = encodeURIComponent(query[key]);
        if (isFirst) {
            url += `?${key}=${value}`;
            isFirst = false;
            return;
        }
        url += `&${key}=${value}`;
    });
    return `${url}${location.hash}`;
}

// 获取Query参数
function getUrlParams(url) {
    const urlParams = new URLSearchParams(url.split('?')[1]);
    const params = {};
    for (let param of urlParams.entries()) {
        params[param[0]] = param[1];
    }
    return params;
}

function setLanguage(lang) {
    // 更新界面文本
    document.querySelectorAll('[data-translate]').forEach(el => {
        const key = el.dataset.translate;
        el.textContent = translations[lang][key];
    });

    // 更新搜索框提示
    document.querySelector('.search-input').placeholder = translations[lang].search;

    // 更新语言按钮
    document.querySelector('.language-btn').innerHTML =
        `<i class="fas fa-globe"></i> ${translations[lang].name}`;

    // 设置文档方向
    document.documentElement.dir = ['ar', 'fa'].includes(lang) ? 'rtl' : 'ltr';

    // 收起弹窗
    document.querySelector('.language-dropdown').classList.toggle('show', false);
}

// 搜索功能
document.querySelector('.search-button').addEventListener('click', performSearch);
document.querySelector('.search-input').addEventListener('keypress', (e) => {
    if (e.key === 'Enter') performSearch();
});

function performSearch() {
    const key = document.querySelector('.search-input').value;
    //if (query.trim()) {
    //    alert(`正在搜索：${query}`);
    // 实际使用时替换为真实搜索逻辑
    // window.location.href = `/search?q=${encodeURIComponent(query)}`;
    //}
    const query = getUrlParams(location.href);
    query.key = key;
    location.href = getQueryUrl(query, "/Product");
}

// 移动端菜单
document.querySelector('#mobile-menu').addEventListener('click', () => {
    document.querySelector('.nav-links').classList.toggle('show');
});

// 语言下拉菜单
document.querySelector('.language-btn').addEventListener('click', () => {
    document.querySelector('.language-dropdown').classList.toggle('show');
});

// 初始化默认语言
// setLanguage('en');

// 站点信息
const $site = window.$site = {};

// 设置布局对齐
$site.setLayoutAlign = (align) => {
    // 设置文档方向
    document.documentElement.dir = align;
};

// 显示获取报价弹窗
$site.showQuotation=()=>{
    document.querySelector('.dig-quotation').style.display = 'flex';
};

// 隐藏获取报价弹窗
$site.hideQuotation=()=>{
    document.querySelector('.dig-quotation').style.display = 'none';
};