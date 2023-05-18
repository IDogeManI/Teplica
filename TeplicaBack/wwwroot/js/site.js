// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const dragAndDrop = () => {
    const cards = document.querySelectorAll('.js-card');
    const cells = document.querySelectorAll('.js-cell');
    let mainCard;
    const click = function () {
        requestToChangeProperties(this.textContent.trim());
    };
    const dragStart = function () {
        mainCard = this;
        setTimeout(() => {
            this.classList.add('hide');
        },0);
    };
    const dragEnd = function () {
        this.classList.remove('hide');
    }
    const dragOver = function (evt) {
        evt.preventDefault();
    }
    const dragEnter = function () {
        this.classList.add('hovered');
    }
    const dragLeave = function () {
        this.classList.remove('hovered');
    }
    const dragDrop = function () {
        this.append(mainCard);
        let a = this.textContent.trim().split('\n');
        requestToRegroup(a[0], mainCard.textContent.trim());
        this.classList.remove('hovered');
    }
    cells.forEach((cell) => {
        cell.addEventListener('dragover', dragOver);
        cell.addEventListener('dragenter', dragEnter);
        cell.addEventListener('dragleave', dragLeave);
        cell.addEventListener('drop', dragDrop);
    });
    cards.forEach((card) => {
        card.addEventListener('dragstart', dragStart);
        card.addEventListener('dragend', dragEnd);
        card.addEventListener('click', click);
    });
};
const requestToRegroup = (group,id) => {
    const message = "Group="+group+"&Id="+id;

    const xhr = new XMLHttpRequest();

    xhr.open("POST", "/Teplica/Regroup");
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    // обработчик получения ответа сервера
    xhr.onload = () => {
        if (xhr.status == 200) {
        } else {
            console.log("Server response: ", xhr.statusText);
        }
    };

    xhr.send(message);
}
const requestToChangeProperties = (id) => {
    const message = "Id=" + id;

    const xhr = new XMLHttpRequest();
    xhr.open("GET", "/Teplica/ChangeProperties?"+message);
    // обработчик получения ответа сервера
    xhr.onload = () => {
        if (xhr.status == 200) {
            var range = document.createRange();
            document.querySelector('.changingModal').innerHTML = '';
            document.querySelector('.changingModal').append(range.createContextualFragment(xhr.responseText));
        } else {
            console.log("Server response: ", xhr.statusText);
        }
    };

    
    xhr.send();
}
dragAndDrop();