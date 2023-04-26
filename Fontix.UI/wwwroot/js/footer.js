window.addEventListener("load", onLoadFunction);

function onLoadFunction(e) {
    onResizeFunction();
    onLoadRenderSelectInput();
    window.addEventListener("resize", onResizeFunction);
    document.querySelectorAll('.select-input').forEach(s => s.addEventListener('click', event => selectOnClickFunction(s)));
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
        let selectWrapper = select.parentNode;

        select.classList.add('select-initialized', 'd-none');

        let formOutline = document.createElement('div');
        formOutline.classList.add('form-outline');

        let input = document.createElement('input');
        input.classList.add("form-control", "select-input", "active");
        input.setAttribute("type", "text");
        input.setAttribute("role", "listbox");
        input.setAttribute("readonly", "true");
        input.setAttribute("form", "disabledInput")
        input.value = select.options[select.selectedIndex].textContent;

        let label = document.createElement('label');
        label.classList.add("form-label", "select-label", "active", "ms-0");
        label.textContent = selectWrapper.querySelector("label").textContent;
        label.setAttribute("role", "listbox");
        label.setAttribute("readonly", "true");

        let selectArrow = document.createElement("span");
        selectArrow.classList.add("select-arrow");

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
        selectWrapper.append(formOutline);
        formOutline.append(input, label, selectArrow, formNotch);
    })
}

function selectOnClickFunction(selectInput) {
    let selectWrapper = selectInput.parentNode.parentNode;
    let select = selectWrapper.querySelector("select");

    let selectDropDownContainer = document.createElement('div');
    selectDropDownContainer.classList.add('select-dropdown-container', 'position-absolute');
    selectDropDownContainer.style.width = selectWrapper.clientWidth + "px";
    console.log(selectWrapper.clientWidth);

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
        const selectDropdownContainer = wrapper.querySelector('.select-dropdown-container');

        // check if the clicked element is inside the select-wrapper element
        if (selectDropdownContainer != null && !wrapper.contains(e.target)) {
            // remove the select-dropdown-container element
            selectDropdownContainer.remove();
        }
    })
}

/* [END] AlecIT - SELECT */