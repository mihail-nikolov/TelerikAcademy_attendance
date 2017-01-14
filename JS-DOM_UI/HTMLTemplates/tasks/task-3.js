function solve() {
    return function() {
        $.fn.listview = function(data) {
            var selector = '#' + this.attr('data-template'),
                templateHTML = $(selector).html(),
                template = handlebars.compile(templateHTML),                
                len = data.length,
                i;

            for (i = 0; i < len; i += 1) {
                this.append(template(data[i]));
            }

            return this;
        };
    };
}

module.exports = solve;