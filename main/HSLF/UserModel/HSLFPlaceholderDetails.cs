/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */

using NPOI.Common.UserModel;
using NPOI.HSLF.Record;
using NPOI.SL.UserModel;
using NPOI.Util;
using System;
using System.Collections.Generic;

namespace NPOI.HSLF.UserModel
{

    /**
     * Extended placeholder details for HSLF sheets - mainly for headers and footers
     *
     * @since POI 4.0.0
     */
    public class HSLFPlaceholderDetails implements PlaceholderDetails {
    private HSLFSheet sheet;
    private Placeholder placeholder;

    HSLFPlaceholderDetails(final HSLFSheet sheet, Placeholder placeholder) {
        this.sheet = sheet;
        this.placeholder = placeholder;
    }


    @Override
    public boolean isVisible() {
        Placeholder ph = getPlaceholder();
        if (ph == null) {
            return false;
        }

        HeadersFooters headersFooters = sheet.getHeadersFooters();

        switch (ph) {
            case HEADER:
            case TITLE:
                return headersFooters.isHeaderVisible();
            case FOOTER:
                return headersFooters.isFooterVisible();
            case DATETIME:
                return headersFooters.isDateTimeVisible();
            case SLIDE_NUMBER:
                return headersFooters.isSlideNumberVisible();
            default:
                return false;
        }
    }

    @Override
    public void setVisible(final boolean isVisible) {
        Placeholder ph = getPlaceholder();
        if (ph == null) {
            return;
        }

        HeadersFooters headersFooters = sheet.getHeadersFooters();

        switch (ph) {
            case TITLE:
            case HEADER:
                headersFooters.setHeaderVisible(isVisible);
                break;
            case FOOTER:
                headersFooters.setFooterVisible(isVisible);
                break;
            case DATETIME:
                headersFooters.setDateTimeVisible(isVisible);
                break;
            case SLIDE_NUMBER:
                headersFooters.setSlideNumberVisible(isVisible);
                break;
        }
    }

    @Override
    public Placeholder getPlaceholder() {
        return placeholder;
    }

    @Override
    public void setPlaceholder(Placeholder placeholder) {
        throw new UnsupportedOperationException("Only sub class(es) of HSLFPlaceholderDetails allow setting the placeholder");
    }

    @Override
    public PlaceholderSize getSize() {
        return PlaceholderSize.full;
    }

    @Override
    public void setSize(PlaceholderSize size) {
        throw new UnsupportedOperationException("Only sub class(es) of HSLFPlaceholderDetails allow setting the size");
    }

    @Override
    public String getText() {
        Placeholder ph = getPlaceholder();
        if (ph == null) {
            return null;
        }

        HeadersFooters headersFooters = sheet.getHeadersFooters();

        switch (ph) {
            case TITLE:
            case HEADER:
                return headersFooters.getHeaderText();
            case FOOTER:
                return headersFooters.getFooterText();
            case DATETIME:
                return headersFooters.getDateTimeText();
            case SLIDE_NUMBER:
            default:
                return null;
        }
    }

    @Override
    public void setText(final String text) {
        Placeholder ph = getPlaceholder();
        if (ph == null) {
            return;
        }

        HeadersFooters headersFooters = sheet.getHeadersFooters();

        switch (ph) {
            case TITLE:
            case HEADER:
                headersFooters.setHeaderText(text);
                break;
            case FOOTER:
                headersFooters.setFootersText(text);
                break;
            case DATETIME:
                headersFooters.setDateTimeText(text);
                break;
            case SLIDE_NUMBER:
            default:
                break;
        }

    }
}