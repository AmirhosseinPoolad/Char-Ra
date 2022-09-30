import glob
from PIL import Image

old_color_yellow = 185,185,0,255
new_color_yellow = 170,131,5,255
old_color_blue = 82,5,124,255
new_color_blue = 25,20,119,255
old_color_red = 185,84,0,255
new_color_red = 153,5,47,255
old_color_green = 0,111,111,255
new_color_green = 68,151,5,255

for path in glob.glob("*.png"):
    if "__out" in path:
        print ("skipping on"), path
        continue

    print ("working on"), path

    im = Image.open(path)
    im = im.convert("RGBA")
    width, height = im.size
    colortuples = im.getcolors()

    pix = im.load()
    for x in range(0, width):
        for y in range(0, height):
            if pix[x,y] == old_color_red:
                im.putpixel((x, y), new_color_red)
            if pix[x,y] == old_color_green:
                im.putpixel((x, y), new_color_green)
            if pix[x,y] == old_color_yellow:
                im.putpixel((x, y), new_color_yellow)
            if pix[x,y] == old_color_blue:
                im.putpixel((x, y), new_color_blue)

    im.save(path)
