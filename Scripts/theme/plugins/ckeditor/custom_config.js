/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.toolbar = [
     
        
        { name: 'basicstyles', items: [ 'Format', 'FontSize' ,'Bold', 'Italic', 'Underline'] },
        { name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
        
        //{ name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
        //{ name: 'insert', items: ['Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
        //{ name: 'document', groups: ['mode', 'document', 'doctools'] },
       
        //{ name: 'tools', items: ['Maximize', 'ShowBlocks', 'Source', 'Preview','AddLayout'] },
       
    ];
    config.extraPlugins = 'basewidget,layoutmanager';
    //config.extraPlugins = "layoutmanager";
    //config.extraPlugins= 'image2';
    config.layoutmanager_loadbootstrap = true;
    config.layoutmanager_allowedContent;
    config.layoutmanager_buttonboxWidth = 58;

    CKEDITOR.config.height = 100;
    //config.extraPlugins = 'layoutmanager';
    //config.image2_alignClasses = ['image-left', 'image-center', 'image-right'];
    //config.image2_captionedClass = 'image-captioned';

};
