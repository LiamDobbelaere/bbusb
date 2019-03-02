# bbusb
## Wiring for Arduino
1. Open the Wii Balance Board, unscrewing everything at the bottom
2. Unplug the cables from the print
3. Unsolder the 4 load cell's connections at the print and remove the print from the balance board
4. Solder the cables with the same colors of the 2 load cells on the left side of the board together, making them parallel.
5. Do the same for the two load cells on the right side of the board
6. Connect these new parallel connections of left and right to two HX711 prints, one for each side. For a RED (sparkfun) HX711, you want to wire them on the left side of the HX711 print in the order Red-White-Blue-Green from top to bottom. Some pins will be left over at the bottom, that's normal. If you have a GREEN HX711 print, the order is Red-White-Green-Blue. If the HX711 print has a VDD and VCC, you should solder these together at the bottom of the print.
7. Make some room inside the balance board by prying out the plastic using large nippers or similar tools.
8. Connect the SCK and DT ports of the first HX711 to A0 and A1 (for instance)
9. Connect the SCK and DT ports of the second HX711 to A2 and A3 (for instance)
10. Plug in the Arduino and upload the .ino file found in the Firmware/bbusb directory
11. Make sure you get readings in the serial window that change as you press onto the load cells
(**Note: The balance board will perform a calibration step of about 4 seconds every time it boots, do not put pressure on the board until the calibration step is finished**)
12. Close up the balance board, removing the button of the balance board and running the USB cable through there
13. Plug in the balance board
14. Download the bbusb GUI from Releases or run the code yourself
15. Run bbusb GUI once and close it, edit the config file to set the right COM port for the balance board
16. Start bbusb GUI with the balance board plugged in and play
