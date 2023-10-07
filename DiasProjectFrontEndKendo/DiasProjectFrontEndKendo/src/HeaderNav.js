import jQuery from 'jquery';
import '@progress/kendo-ui/js/kendo.menu';

export const init = () => {
    window.jQuery = window.$ = jQuery;

    $("#header").kendoMenu({
        dataTextField: "text",
        dateUrlField: "url",
        dataSource: [
            { text: "Home", url: "/" },
        ]
    });
}
