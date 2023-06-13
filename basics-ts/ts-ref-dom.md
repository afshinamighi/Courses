## Document Object Model (DOM)

The Document Object Model (DOM) is a programming interface for HTML and XML documents. It represents the structure of a web page as a tree-like structure, where each element in the tree corresponds to a node in the document. The DOM provides a way to access, manipulate, and interact with these nodes dynamically.

As an example check the following html file and coresponding TypeScript program:

```html
<!DOCTYPE html>
<html>
<head>
  <title>DOM and TypeScript Tutorial</title>
</head>
<body>
  <h1>DOM and TypeScript Tutorial</h1>
  <div id="content"></div>
  <script src="app.js"></script>
</body>
</html>
```


```typescript
// Accessing Elements by ID
const titleElement = document.getElementById("content");
if (titleElement) {
  titleElement.innerHTML = "Hello, DOM!";
}

// Creating and Appending Elements
const paragraphElement = document.createElement("p");
paragraphElement.innerHTML = "This is a dynamically created paragraph.";
document.body.appendChild(paragraphElement);

// Modifying Element Attributes
paragraphElement.setAttribute("class", "highlight");

// Event Handling
paragraphElement.addEventListener("click", () => {
  alert("Paragraph clicked!");
});
```


Running the program in a web browser, you should see the text `"Hello, DOM!"` displayed on the page. Additionally, a dynamically created paragraph 
should be appended to the body of the HTML document. When you click on the paragraph, an alert message saying `"Paragraph clicked!"` should appear.

Explanation:

Accessing Elements by ID:

document.getElementById("content") retrieves the element with the id "content" from the DOM.
titleElement.innerHTML sets the HTML content of the titleElement to "Hello, DOM!".
Creating and Appending Elements:

document.createElement("p") creates a new <p> element.
paragraphElement.innerHTML sets the HTML content of the paragraphElement.
document.body.appendChild(paragraphElement) appends the paragraphElement as a child to the <body> element.
Modifying Element Attributes:

paragraphElement.setAttribute("class", "highlight") sets the class attribute of the paragraphElement to "highlight".
Event Handling:

paragraphElement.addEventListener("click", () => { ... }) adds a click event listener to the paragraphElement.
When the paragraph is clicked, the code inside the arrow function is executed, triggering an alert message.
By using TypeScript in combination with the DOM, you can manipulate and interact with HTML elements dynamically. This tutorial covers basic operations 
like accessing elements by ID, creating and appending elements, modifying attributes, and handling events. These concepts serve as a foundation for 
more complex DOM manipulations and web development.
