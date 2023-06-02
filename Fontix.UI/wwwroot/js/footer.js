window.addEventListener("load", onLoadFunction);

function onLoadFunction(e) {
    onResizeFunction();
    onLoadRenderSelectInput();
    window.addEventListener("resize", onResizeFunction);
    document.querySelectorAll('.select-input, .select-input ~ i').forEach(s => s.addEventListener('click', event => selectOnClickFunction(s)));
}

function onResizeFunction(e) {
    let footer = document.getElementsByTagName("footer")[0];
    let height = footer.scrollHeight;
    console.log(height);
    document.getElementById("content-wrap").style.paddingBottom = height + "px";
}


/* [BEGIN] AlecIT - SELECT */
function onLoadRenderSelectInput() {
    document.querySelectorAll('.select').forEach(select => {
        const small = select.classList.contains('select-small');

        let selectWrapper = select.parentNode;

        select.classList.add('select-initialized', 'd-none');

        let formOutline = document.createElement('div');
        formOutline.classList.add('form-outline');


        let input = document.createElement('input');
        input.classList.add("form-control", "select-input", "active");
        if (small) {
            input.classList.add("select-small-input", "fw-bold", "p-0");
        }
        input.setAttribute("type", "text");
        input.setAttribute("role", "listbox");
        input.setAttribute("readonly", "true");
        input.setAttribute("form", "disabledInput")
        input.value = select.options[select.selectedIndex].textContent;

        selectWrapper.append(formOutline);
        formOutline.append(input)

        if (!small) {
            let label = document.createElement('label');
            label.classList.add("form-label", "select-label", "active", "ms-0");
            label.textContent = selectWrapper.querySelector("label").textContent;
            label.setAttribute("role", "listbox");
            label.setAttribute("readonly", "true");

            let formNotch = document.createElement("div");
            formNotch.classList.add("form-notch");

            let formNotchLeading = document.createElement("div");
            formNotchLeading.classList.add("form-notch-leading");
            formNotchLeading.style.width = "9px";
            let formNotchMiddle = document.createElement("div");
            formNotchMiddle.classList.add("form-notch-middle");
            let formNotchTrailing = document.createElement("div");
            formNotchTrailing.classList.add("form-notch-trailing");

            let labelWidth = document.createElement("label");
            labelWidth.classList.add("position-absolute");
            labelWidth.style.fontSize = "0.9rem";
            labelWidth.style.transform = "scale(0.8)";
            labelWidth.textContent = label.textContent;
            document.querySelector('body').append(labelWidth)
            formNotchMiddle.style.width = (labelWidth.getBoundingClientRect().width + 8) + "px";

            selectWrapper.querySelector("label").remove();
            labelWidth.remove();
            formNotch.append(formNotchLeading, formNotchMiddle, formNotchTrailing);

            formOutline.append(label);
            formOutline.append(formNotch);
        } else {
            let selectArrow = document.createElement("i");
            selectArrow.classList.add("fas", "fa-caret-down", "select-small-caret");
            formOutline.append(selectArrow);


            // window.addEventListener('DOMContentLoaded', function () {


            function measureTextWidth(text) {
                const span = document.createElement('span');
                span.style.visibility = 'hidden';
                span.style.position = 'absolute';
                span.style.whiteSpace = 'nowrap';
                span.style.fontSize = window.getComputedStyle(input).fontSize;
                span.style.fontWeight = window.getComputedStyle(input).fontWeight;
                span.textContent = text;
                document.body.appendChild(span);
                const width = span.offsetWidth;
                document.body.removeChild(span);
                return width;
            }

            function setInputWidth() {
                const inputValue = input.value;
                const textWidth = measureTextWidth(inputValue);
                input.style.width = `${textWidth}px`;
                selectArrow.classList.add("show");
            }

            setInputWidth();
            // If the input value changes dynamically, update the width accordingly
            input.addEventListener('input', setInputWidth);
            // });
        }
    })
}

function selectOnClickFunction(selectInput) {
    let selectWrapper = selectInput.parentNode.parentNode;
    let select = selectWrapper.querySelector("select");
    const small = select.classList.contains('select-small');

    let container = selectWrapper.querySelector('.select-dropdown-container');
    if (container != null) {
        container.remove();
    }

    let selectDropDownContainer = document.createElement('div');
    selectDropDownContainer.classList.add('select-dropdown-container', 'position-absolute');
    if (!small) {
        selectDropDownContainer.style.width = selectWrapper.clientWidth + "px";
        console.log(selectWrapper.clientWidth);
    }

    let selectDropdown = document.createElement("div");
    selectDropdown.classList.add('select-dropdown');
    setTimeout(() => {
        selectDropdown.classList.add('open');
    }, 50)

    let selectOptionsWrapper = document.createElement("div");
    selectOptionsWrapper.classList.add('select-options-wrapper');

    let selectOptionsList = document.createElement("div");
    selectOptionsList.classList.add('select-options-list');


    Array.from(select.children).forEach(option => {
        let selectOption = document.createElement("div");
        selectOption.classList.add('select-option');
        selectOption.addEventListener('click', function () {
            select.value = option.value;
            // Create a new event
            let event = new Event('change');
            // Dispatch the event
            select.dispatchEvent(event);
            selectInput.value = option.textContent;
            selectDropDownContainer.remove();
        })


        let selectOptionText = document.createElement("span");
        selectOptionText.classList.add('select-option-text');
        selectOptionText.textContent = option.textContent;


        selectOption.append(selectOptionText);
        selectOptionsList.append(selectOption);
    })

    selectWrapper.append(selectDropDownContainer);
    selectDropDownContainer.append(selectDropdown);
    selectDropdown.append(selectOptionsWrapper);
    selectOptionsWrapper.append(selectOptionsList);
}

window.addEventListener("click", onClickOutsideSelect)


const selectWrappers = Array.from(document.querySelectorAll('.select-wrapper'));

function onClickOutsideSelect(e) {
    selectWrappers.forEach((wrapper) => {
        const selectDropdownContainers = wrapper.querySelectorAll('.select-dropdown-container');

        selectDropdownContainers.forEach(container => {
            // check if the clicked element is inside the select-wrapper element
            if (container != null && !wrapper.contains(e.target)) {
                // remove the select-dropdown-container element
                container.remove();
            }
        })
    })
}

/* [END] AlecIT - SELECT */


/* [BEGIN] AlecIT - NAVBAR */
let nav = document.querySelector(".fontix-nav")
let burger = nav.querySelector('.burger');

burger.addEventListener('click', function () {
    let navtimeout;
    if (this.classList.contains("collapsed")) {
        clearTimeout(navtimeout);
        nav.style.height = 'calc(100vh - calc(100vh - 100%))';

        this.classList.remove("collapsed");
        this.parentNode.classList.remove("collapsed");
        this.parentNode.parentNode.classList.remove("collapsed");

        this.classList.add("expanded");
        this.parentNode.classList.add("expanded");
        this.parentNode.parentNode.classList.add("expanded");

        nav.querySelectorAll('.menu ul li').forEach(li => li.classList.add("aos-animate"));
    } else if (this.classList.contains("expanded")) {
        navtimeout = setTimeout(() => {
            nav.style.height = '';
        }, 700);

        this.classList.remove("expanded");
        this.parentNode.classList.remove("expanded");
        this.parentNode.parentNode.classList.remove("expanded");

        this.classList.add("collapsed");
        this.parentNode.classList.add("collapsed");
        this.parentNode.parentNode.classList.add("collapsed");

        nav.querySelectorAll(".menu ul li").forEach(li => li.classList.remove("aos-animate"));
    }
});


/* [END] AlecIT - NAVBAR */