// 1. 圖片放大功能
// 顯示圖片的 modal
function showImageModal(src) {
    var modal = document.getElementById('imgModal');
    var img = document.getElementById('imgModalContent');
    img.src = src;
    modal.style.display = 'flex';
}
// 關閉圖片的 modal
function closeImageModal() {
    var modal = document.getElementById('imgModal');
    modal.style.display = 'none';
    document.getElementById('imgModalContent').src = '';
}
// 防止點擊圖片本身時關閉 modal
document.getElementById('imgModalContent').onclick = function (event) {
    event.stopPropagation();
};
// 防止點擊關閉按鈕時冒泡
document.querySelector('.img-modal-close').onclick = function (event) {
    event.stopPropagation();
    closeImageModal();
};

// 2. 刪除確認
function confirmDelete() {
    return confirm('確定要刪除嗎？');
}