import { Component, Input, Output, EventEmitter, OnDestroy } from '@angular/core';

declare var tinymce: any;

@Component({
  selector: 'app-tinymce-editor',
  templateUrl: './tinymce-editor.component.component.html',
  styleUrls: ['./tinymce-editor.component.component.css']
})
export class TinymceEditorComponent  implements OnDestroy{

  @Input() elementId: String;
  @Input() content: String;
  @Output() onEditorContentChange = new EventEmitter();
  options: any;

  editor;

  constructor() {
  }

  ngOnChanges(changes: any) {
      this.updateEditor(); 
  }

  updateEditor()
  {
      if (this.content)
          this.editor.setContent(this.content);
  }
  ngAfterViewInit() {
      //let that = this;
      tinymce.init({
          selector: '#' + this.elementId,
          skin_url: '/assets/tinymce/skins/lightgray',
          height: "250",
          plugins: 'link code',
          relative_urls: false,
          toolbar: 'undo redo | bold italic |formats| alignleft aligncenter alignright | code | addImagebutton',
          setup: editor => {
              this.editor = editor;
              editor.on('init', () => {
                  this.updateEditor();
              });
              editor.on('keyup change', () => {
                  const content = editor.getContent();
                  this.onEditorContentChange.emit(content);
              });
              editor.addButton('addImagebutton', {
                  icon: 'image',
                  onclick: function (e) {
                      /*that.uploadImageModalService.showModal().subscribe((link) => {
                          if (link) {
                              editor.insertContent('<img src="' + link + '"/>');
                              const content = editor.getContent();
                              if (this.onEditorContentChange)
                                  this.onEditorContentChange.emit(content);
                          }
                      });*/
                  }
              });
          }
      });
  }

  ngOnDestroy() {
      tinymce.remove(this.editor);
  }

}
