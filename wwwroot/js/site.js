// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Custom client-side validation for date comparisons
jQuery.validator.addMethod("futuredate", function (value, element) {
    if (!value) return true;
    var today = new Date();
    var inputDate = new Date(value);
    return inputDate >= today.setHours(0, 0, 0, 0);
}, "Date cannot be in the past");

jQuery.validator.addMethod("dategreaterthan", function (value, element, params) {
    if (!value) return true;
    var startDateValue = $(params).val();
    if (!startDateValue) return true;
    
    var startDate = new Date(startDateValue);
    var endDate = new Date(value);
    return endDate > startDate;
}, "End date must be after start date");

// Add unobtrusive validation adapters
jQuery.validator.unobtrusive.adapters.add("futuredate", function (options) {
    options.rules["futuredate"] = true;
    options.messages["futuredate"] = options.message;
});

jQuery.validator.unobtrusive.adapters.add("dategreaterthan", ["other"], function (options) {
    options.rules["dategreaterthan"] = "#" + options.params.other;
    options.messages["dategreaterthan"] = options.message;
});

// Auto-submit forms on filter changes
$(document).ready(function () {
    // Auto-submit filter forms
    $('select[name="filterByRole"], select[name="filterByTraineeId"], select[name="filterBySessionId"]').on('change', function () {
        $(this).closest('form').submit();
    });
    
    // Initialize datetime-local inputs with proper format
    $('input[type="datetime-local"]').each(function() {
        if (!$(this).val()) {
            var now = new Date();
            now.setMinutes(now.getMinutes() - now.getTimezoneOffset());
            $(this).val(now.toISOString().slice(0, 16));
        }
    });
});
