let modalCloseBtn = document.querySelectorAll(".modal-close-btn")

if (modalCloseBtn !== null && modalCloseBtn !== undefined) {
    modalCloseBtn.forEach(element => {
        element.addEventListener("click", ()=>{
            element.closest("section").remove()
        })
    });
}