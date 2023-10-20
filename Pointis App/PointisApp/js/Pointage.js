
async function ShowData() {
  console.log('test');
  await fetch("https://face.activactions.net/api/Pointage/Month/3508")
  .then(res => res.json())
  .then(data => {
    console.log(data);
    const template = document.getElementById("table-template").innerHTML;
    const renderedTable = Mustache.render(template, { data });
    document.getElementById("table-body").innerHTML = renderedTable;
  });
}

ShowData(); 
  