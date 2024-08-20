# dmit1530-lab-01

## In Class Lab #1 - Flexbox Layout
**Due**: Sunday @ 23:55 Edmonton Time
**Weight**: 5% of your final grade

## Instructions

Clone a copy of this repository to your device so that you can develop locally. When you are finished, make sure to push your latest commit to GitHub Classroom. 

On Moodle, in your Lab 01 instructions, you have been provided with a series of screenshots. You are tasked with adding the HTML and CSS needed to create the provided layout.  

### The Build Methodology 

#### Writing the HTML

1.	Add the HTML elements required to create a layout matching the screenshots. Use semantic HTML 5 elements and check the document structure in the HTML 5 outliner tool. There should be no _Untitled Sections_ and the heading structure should match the provided example below. 

> Responsive Flex Layout
>> Fluid & Responsive Flex Items
>> Sub-Heading
>> Sub-Heading
>> Sub-Heading
>> Sub-Heading

2.	For the images, use placeholder images with a 500px by 400px dimension. You can do this by using the following code in your HTML:

`` <img src="https://source.unsplash.com/random/500x400" alt="A random photograph with 500px by 400px dimensions."> ``

3.	Give the first column and the final column two paragraphs of filler text (either generic lorem ipsum or a generator of your choice). Use only one paragraph of filler text for the other two columns.

4.	In your footer, add a link to the following article: 

`` https://www.smashingmagazine.com/2011/01/guidelines-for-responsive-web-design/ `` 

5.	Validate your HTML and repair any deficiencies. Any lab that throws a validation error will not be accepted.

#### Writing the CSS

6.	Starting with the styles needed for the smallest view, add the necessary CSS.

7.	The font sizing should render as follows: h1 heading 40px, h2 heading 30px, h3 heading 24px, and the body paragraph text 16px. 

**Note**: Do not use pixel values in your code. Your fonts should be sized in _relative units_.

8.	Style the header element to roughly match the screenshots. Give the header a bottom margin. It should render as 24px, but your code must use relative units.

9.	Each column will have a 1px border and 1rem of padding. On the smallest screen the columns will stack vertically, and they will need 1rem of margin on the top and the bottom to separate them.

10.	Inside the columns, the images will be placed on the left with the text on the right. The image should be vertically aligned to the centre. Give the images 40% of the available space and add 1rem of margin on the right side to move the text over. The text will take up the remaining room on the row.

11. In the footer, centre your text and ensure there is at least 2rem of padding on the top and bottom.

#### Adding Media Queries

12.	When the screen is wide enough to fit two columns across horizontally, create a media query for that width and change the layout of the columns. 

In this view, each column will take up 49% of the space on the row with the remaining 2% of space in-between them.

13.	Once the browser viewport is wide enough and the website layout changes, the layout inside of the columns will change too. Instead of being beside the text, the images will be on top (i.e. like a polaroid photo) with the text below. The images must be flexible, responsive, and they cannot be larger than the container element they are in.

### On Your Own

14. Write a final media query for when the viewport reaches its largest size. The layout should **stop growing** or shrinking (i.e. switch to a fixed-width layout) and be **centred**. 

The **background colours** should still span the entire width of the viewport, no matter what its size is. 

15. Push your assignment files back up to GitHub Classroom.
