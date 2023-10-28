function LeapYear(year) {
    console.log(((0 === year % 4) && (0 !== year % 100) || (0 === year % 400)) ? 'yes' : 'no');
}

LeapYear(1984); // yes
LeapYear(2003); // no
LeapYear(4); // yes
LeapYear(1900); // no