# VeriParkTask

VeriPark Penalty Calculator Task

Task Result: ✓ Passed

Requirements
1) Develop a web page on which users will input

a. Date the book is checked out.

b. Date the book is returned.

c. Country selection (at least 2 different countries)

d. Calculate button The web page should display

2) Calculated Business Days

a. Calculated penalty for the inputs.

3) Penalty should be calculated for BUSINESS days only between the checkout and returned days of the book. The checkout and return dates are inclusive.

a. It should consider weekends and national holidays/religious holidays defined in tables in database for a specific country.

b. Note that some countries have different working days and weekends. For example in Dubai Friday and Saturday are off days. However in Turkey Saturday and Sunday are off days.

c. Your code should not have these assumptions hardcoded but they must be in configurations. The configuration should be kept in a database table.

d. Do not provide a screen to edit these values in the database. Manual editing of these values is sufficient.

e. You should develop your own algorithm for business day count.
• Hint: Try to use DayOfWeek enumeration of .Net for weekends.

4) Each late business day will be penalized for 5.00 $ (or currency code of country)

a. The currency code and the amount is country specific.

b. Penalty amount should be a decimal value to accommodate for cents and fills and etc.

5) Any monetary value you display on the screen should have proper formatting
