function leapYear(year) {
    console.log(((0 === year % 4) && (0 !== year % 100) || (0 === year % 400)) ? 'yes' : 'no');
}

leapYear(1984); // yes
leapYear(2003); // no
leapYear(4); // yes
leapYear(1900); // no