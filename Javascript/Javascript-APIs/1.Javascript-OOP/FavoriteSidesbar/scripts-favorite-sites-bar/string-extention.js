
if (!String.format) {
    String.format = function stringFormat() {
        var text = arguments[0];
        //// finding only first match of reg expresion one or more digits in { }.
        var placeholdStartIndex = text.indexOf(text.match(/{\d+}/));
        var placeholdEndIndex;
        var placeholdNum;
        //// while there is match
        while (placeholdStartIndex > 0) {

            placeholdEndIndex = ++placeholdStartIndex; // from placeholStartIndex = ++placeholdPos to placeholEndIndex  to get the length of placeholdIndex
            for (var i = placeholdStartIndex; text.charAt(i) !== '}'; i++) {
                placeholdEndIndex++;
            }

            placeholdNum = parseInt(text.substring(placeholdStartIndex, placeholdEndIndex), 10) + 1;
            if (arguments[placeholdNum] === undefined) {
                throw new Error('FormatError: The index of a format item is less than zero, or greater than or equal to the length of the args array.');
            }
            text = text.replace(/{\d+}/, arguments[placeholdNum]);
            placeholdStartIndex = text.indexOf(text.match(/{\d+}/));
        }

        return text;
    }
}